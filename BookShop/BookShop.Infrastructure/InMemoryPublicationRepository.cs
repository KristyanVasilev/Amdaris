﻿namespace BookShop.Infrastructure
{
    using BookShop.Application.Contracts;
    using BookShop.Domain;

    public class InMemoryPublicationRepository : IPublicationRepository
    {
        private readonly List<Publication> publications;

        public InMemoryPublicationRepository()
        {
            this.publications = new List<Publication>();
        }

        public void CreatePublication(Publication publication)
        {
            this.publications.Add(publication);
        }

        public string DeletePublication(int id)
        {
            var publicationToRemove = GetSinglePublication(id);         
            this.publications.Remove(publicationToRemove);

            return $"Publication with Id - {id} deleted succesufuly!";
        }

        public IEnumerable<Publication> GetPublications()
        {
            return this.publications;
        }

        public Publication GetSinglePublication(int id)
        {
            var result = this.publications.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                throw new InvalidOperationException("Publiaction not found!");
            }

            return result;
        }
    }
}
