ALTER TABLE TheClassOptionsLinks ADD Constraint
                [FK_TheClassOptionsLink.Theclass->TheClass]
                FOREIGN KEY (Theclass)
                REFERENCES TheClasses (ID)
                ON DELETE NO ACTION;
GO
ALTER TABLE TheClassOptionsLinks ADD Constraint
                [FK_TheClassOptionsLink.Theoption->TheOption]
                FOREIGN KEY (Theoption)
                REFERENCES TheOptions (ID)
                ON DELETE NO ACTION;
GO