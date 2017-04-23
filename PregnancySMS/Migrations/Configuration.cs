namespace PregnancySMS.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PregnancySMS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PregnancySMS.Models.ApplicationDbContext context)
        { 

            context.Advice.AddOrUpdate(

                new Advice { Id=1, Trimester=1, AdviceText="Taking prenatal vitamins every day can help prevent certain birth defects that affect your baby's brain, heart, and spinal cord."},
                new Advice { Id=2, Trimester=1, AdviceText="With your partner, create a family health history, including any genetic or chromosomal disorders."},
                new Advice { Id=3, Trimester=1, AdviceText= "Quit smoking, and cut out any other bad health habits."},
                new Advice { Id=4, Trimester=2, AdviceText= "Start thinking about flat comfortable shoes." },
                new Advice { Id=5, Trimester=2, AdviceText= "Know the signs and symptoms of preeclampsia" },
                new Advice { Id=6, Trimester=2, AdviceText= "Time for your glucose screening." },
                new Advice { Id=7, Trimester=3, AdviceText= "Begin seeing Doctor every two weeks."},
                new Advice { Id=8, Trimester=3, AdviceText= "Baby proof your house." },
                new Advice { Id=9, Trimester=3, AdviceText= "Know the signs of premature labor." }

           );
            
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
