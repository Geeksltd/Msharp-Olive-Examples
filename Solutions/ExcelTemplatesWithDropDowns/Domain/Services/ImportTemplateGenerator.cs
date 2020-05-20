using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Olive.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ImportTemplateGenerator
    {
        private const string BRANDS = "Brands";
        private const string PRODUCTS = "Products";

        readonly IDatabase Database;

        public string ContentType => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        public ImportTemplateGenerator(IDatabase database) => Database = database;

        public async Task<byte[]> Generate()
        {
            using (var stream = new MemoryStream(Properties.Resources.ImportTemplate))
            {
                var excel = new XSSFWorkbook(stream);

                var brands = await Database.Of<Brand>()
                    .OrderBy(x => x.Name)
                    .GetList();

                var counter = 0;
                foreach (var brand in brands)
                    await AddBrand(excel, brand, counter++);

                Protect(excel, BRANDS);
                Protect(excel, PRODUCTS);

                using (var result = new MemoryStream())
                {
                    excel.Write(result);
                    return result.ToArray();
                }
            }
        }

        private void Protect(XSSFWorkbook excel, string sheetName)
        {
            var sheet = excel.GetSheet(sheetName);
            sheet.ProtectSheet("123");
        }

        private async Task AddBrand(
            XSSFWorkbook excel,
            Brand brand,
            int index)
        {
            var brandSheet = excel.GetSheet(BRANDS);

            var row = brandSheet.GetOrCreateRow(index);

            row.GetOrCreateCell(0).SetCellValue(brand.Name);
            row.GetOrCreateCell(1).SetCellValue(index + 1);

            var products = await Database.Of<Product>()
                .Where(x => x.BrandId == brand)
                .OrderBy(x => x.Title)
                .GetList();

            var counter = 0;

            var productsSheet = excel.GetSheet(PRODUCTS);

            foreach (var location in products)
                productsSheet.GetOrCreateCell(counter++, index)
                    .SetCellValue(location.Title);
        }
    }

    static class NPOIExcelExtenions
    {
        public static IRow GetOrCreateRow(this ISheet @this, int index)
        {
            var result = @this.GetRow(index);

            if (result == null)
                result = @this.CreateRow(index);

            return result;
        }

        public static ICell GetOrCreateCell(this IRow @this, int index)
        {
            var result = @this.GetCell(index);

            if (result == null)
                result = @this.CreateCell(index);

            return result;
        }

        public static ICell GetOrCreateCell(this ISheet @this, int rowIndex, int colIndex) =>
            @this.GetOrCreateRow(rowIndex).GetOrCreateCell(colIndex);
    }
}
