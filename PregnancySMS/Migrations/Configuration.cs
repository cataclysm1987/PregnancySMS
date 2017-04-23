namespace PregnancySMS.Migrations
{
    using PregnancySMS.Models;
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
            context.Messages.AddOrUpdate(
                new Message { Id = 1, MessageText = "Thank you for using Pregnancy SMS. If this is an emergency, please call 911. Otherwise, we just need to ask a few questions. First, how long have you been pregnant? Please reply with the number of weeks or \"I don't know\".", NextMessageId = 2 },
                new Message { Id = 2, MessageText = "Do you have a doctor to see? Please reply with \"yes\" or \"no\".", NextMessageId = 3 },
                new Message { Id = 3, MessageText = "Do you have health insurance? Please reply with \"yes\" or \"no\".", NextMessageId = 4 },
                new Message { Id = 4, MessageText = "Are you satisfied with your access to healthy foods? Please reply with \"yes\" or \"no\".", NextMessageId = 5 },
                new Message { Id = 5, MessageText = "What is your zip code?", NextMessageId = 6 },
                new Message { Id = 6, MessageText = "Thank you! We can now send you daily advice like this: " },
                new Message { Id = 7, MessageText = "To stop your daily advice, send \"stop\"." }
            );
        }
    }
}
