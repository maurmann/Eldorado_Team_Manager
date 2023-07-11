using Bogus;
using System.Globalization;
using System.Text;
using TeamManager.Domain.Entities;

namespace TeamManager.DataAccess
{
    public static class FakeData
    {
        public static List<Collaborator> GenerateCollaborators()
        {
            var collaboratorFaker = new Faker<Collaborator>("pt_BR")
                .RuleFor(c => c.Id, f => f.IndexFaker)
                .RuleFor(c => c.Name, f => f.Name.FullName())
                .RuleFor(c => c.Email, f => f.Internet.Email())
                .RuleFor(c => c.UnitId, f => f.PickRandom(new int[] { 1, 2, 3, 4 }))
                .RuleFor(c => c.TeamId, f => f.PickRandom(new int?[] { null, 20, 21, 22, 29, 38, 39, 40, 41 }));

            var collaborators = collaboratorFaker.Generate(10_000);

            var distinctCollaborators = new List<Collaborator>();
            foreach (var collaborator in collaborators)
            {
                if (!distinctCollaborators.Any(x => x.Name == collaborator.Name))
                    distinctCollaborators.Add(collaborator);

                if (distinctCollaborators.Count == 1900)
                    break;
            }

            foreach (var collaborator in distinctCollaborators)
            {
                var names = collaborator.Name.Split(' ');
                var email = string.Concat(RemoveAccents(names[0].ToLower()), ".", RemoveAccents(names[1].ToLower()), "@eldorado.org.br");
                collaborator.Email = email;
            }

            return distinctCollaborators;
        }

        private static string RemoveAccents(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder(capacity: normalizedString.Length);

            for (int i = 0; i < normalizedString.Length; i++)
            {
                char c = normalizedString[i];
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder
                .ToString()
                .Normalize(NormalizationForm.FormC);
        }
    }
}
