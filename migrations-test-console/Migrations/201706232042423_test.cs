using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Annotations;

namespace migrations_test_console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foos", "TestViewObj_testfield",
                c => c.Int(nullable: false
                // What i think should also be generated
                //                ,annotations: new Dictionary<string, AnnotationValues>    
                //                {
                //                    {
                //                        "RemoveViewAttribute",
                //                        new AnnotationValues(oldValue: null, newValue: "")
                //                    },
                //                }
                ));
        }

        public override void Down()
        {
            DropColumn("dbo.Foos", "TestViewObj_testfield");
        }
    }
}