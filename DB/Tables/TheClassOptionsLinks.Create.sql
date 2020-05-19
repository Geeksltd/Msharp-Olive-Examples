-- TheClassOptionsLinks Table ========================
CREATE TABLE TheClassOptionsLinks (
    Id uniqueidentifier PRIMARY KEY NONCLUSTERED,
    Theclass uniqueidentifier  NOT NULL,
    Theoption uniqueidentifier  NOT NULL
);
CREATE INDEX [IX_TheClassOptionsLinks->Theclass] ON TheClassOptionsLinks (Theclass);

GO

