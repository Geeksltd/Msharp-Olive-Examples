### To create a UI like below which the user can select one or have multi-select. All you need is to follow the following steps.

You can find the project [here](/Solutions/CustomRadioButtons)

![](/Assets/CustomRadioButtons.png)


First, create your module as you always do and use AsRadioButton for single select and AsCheckBoxes for multi-select. This method has a parameter for an image URL and FA icon name. And if you only have text there is a Boolean param which should be true. You may need to apply some styling when using images.

 

Here is the module for above sample
```csharp
Field(x => x.Type).Mandatory()
    .AsRadioButtons(Arrange.Horizontal, imageUrl: "item.Image.Url()");

Field(x => x.OptionsLinks)
    .AsCheckBoxes(Arrange.Horizontal, faIconName: "item.Brand.ToLower()");
```

> If you use an old project which is not uses the new styling files add the following part somewhere in your styles.

```scss
.as-buttons-input
{
    .group-control
    {
        max-width: 100%;

        input[type=radio],
        input[type=checkbox]
        {
            opacity: 0;
            position: absolute;

            & + label
            {
                cursor: pointer;
                background-color: white;
                border-radius: $border-radius;
                @extend .p-3;

                i
                {
                    @extend .mx-2;
                }
            }

            &:checked + label
            {
                color: white;
                background-color: $color-primary;
            }
        }
    }
}
```