using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace migrations_test_console
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class TestContext : DbContext
    {
        public DbSet<Foo> Foos { get; set; }

        public TestContext() : base("Context")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(
                new AttributeToTableAnnotationConvention<RemoveViewAttribute, string>(
                    "RemoveViewAnnotation",
                    (property, attributes) => "test"));
            base.OnModelCreating(modelBuilder);
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class RemoveViewAttribute : Attribute
    {
    }

    public class Foo
    {
        public int Id { get; set; }

        public Test TestViewObj { get; set; }
    }
    
    [RemoveView]
    public class Test
    {
        public int testfield { get; set; }
    }
}