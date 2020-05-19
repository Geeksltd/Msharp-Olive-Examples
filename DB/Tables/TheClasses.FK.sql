ALTER TABLE TheClasses ADD Constraint
                [FK_TheClass.Type->TheType]
                FOREIGN KEY (Type)
                REFERENCES TheTypes (ID)
                ON DELETE NO ACTION;
GO