using Microsoft.EntityFrameworkCore;

namespace LearnHubAPP.Models
{
    public class LearnHubDbContext : DbContext
    {
        public DbSet<Formation>? Formations { get; set; }
        public DbSet<Formateur>? Formateurs { get; set; }
        public DbSet<Categorie>? Categories { get; set; }
        public DbSet<Module>? Modules { get; set; }

        private readonly LearnHubDbContext _context;

        public LearnHubDbContext(DbContextOptions<LearnHubDbContext> options) : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Formateur>().HasData(
                new Formateur { Id = 1, Nom = "john", Prenom = "doe", Email = "john.doe@example.com", Biographie = "professeur à l'université de nantes et formateur en data science depuis 2010" },
                new Formateur { Id = 2, Nom = "jane", Prenom = "smith", Email = "jane.smith@example.com", Biographie = "expert en cybersécurité." }
            );

            modelBuilder.Entity<Categorie>().HasData(
                new Categorie { IdCategorie = 1, NomCategorie = "Data Science", DescriptionCat = "catégorie de formation axée sur l'apprentissage de la science des données et de l'analyse de données." },
                new Categorie { IdCategorie = 2, NomCategorie = "Cybersécurité", DescriptionCat = "catégorie de formation axée sur la sécurité informatique et la protection des systèmes informatiques." }
            );

            modelBuilder.Entity<Formation>().HasData(
              new Formation { IdFormation = 1, NomFormation = "Formation en data science avancée", Duree = "3 mois", Description = "formation avancée en data science", Prix = 1000.0f, IdFormateur = 1, IdCategorie = 1, ImgFormationPath = "dddd" },
             new Formation { IdFormation = 2, NomFormation = "Formation en cybersécurité professionnelle", Duree = "2 mois", Description = "formation professionnelle en cybersécurité", Prix = 800.0f, IdFormateur = 2, IdCategorie = 2, ImgFormationPath = "gggg" }
            );

            modelBuilder.Entity<Module>().HasData(
               new Module
               {
                   IdModule = 1,
                   NomModule = "Introduction à la Data Science",
                   DescriptionMod = "Ce module couvre les bases de la data science, y compris les statistiques, le traitement des données et la visualisation.",
                   IdFormation = 1
               },
               new Module
               {
                   IdModule = 2,
                   NomModule = "Machine Learning",
                   DescriptionMod = "Les étudiants exploreront les concepts avancés du machine learning et leur application pratique.",
                   IdFormation = 1
               },
               new Module
               {
                   IdModule = 3,
                   NomModule = "Big Data",
                   DescriptionMod = "Ce module se concentre sur les technologies et les techniques de gestion des grands volumes de données.",
                   IdFormation = 1
               },
               new Module
               {
                   IdModule = 4,
                   NomModule = "Sécurité des Réseaux",
                   DescriptionMod = "Dans ce module, les étudiants apprendront les principes fondamentaux de la sécurité des réseaux et des systèmes d'information.",
                   IdFormation = 2
               },
               new Module
               {
                   IdModule = 5,
                   NomModule = "Cryptographie",
                   DescriptionMod = "Ce module aborde les techniques de cryptage et de protection des données.",
                   IdFormation = 2
               },
               new Module
               {
                   IdModule = 6,
                   NomModule = "Gestion des Risques en Cybersécurité",
                   DescriptionMod = "Les étudiants étudieront les stratégies de gestion des risques et de réponse aux incidents de sécurité.",
                   IdFormation = 2
               }
           );

           // modelBuilder.Entity<Formation>()
           // .HasMany(f => f.Modules)
           // .WithOne(m => m.Id)
           // .HasForeignKey(m => m.IdCategorie);
           
            base.OnModelCreating(modelBuilder);


        }

    }
}
