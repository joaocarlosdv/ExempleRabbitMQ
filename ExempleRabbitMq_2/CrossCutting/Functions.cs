using System;
using System.Linq;

namespace ExempleRabbitMq_2.CrossCutting
{
    public class Functions
    {
        public static string RandomCpf()
        {
            var random = new Random();

            int soma = 0;
            int resto = 0;
            int[] multiplicadores = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string semente;

            do
            {
                semente = random.Next(1, 999999999).ToString().PadLeft(9, '0');
            }
            while (
                semente == "000000000"
                || semente == "111111111"
                || semente == "222222222"
                || semente == "333333333"
                || semente == "444444444"
                || semente == "555555555"
                || semente == "666666666"
                || semente == "777777777"
                || semente == "888888888"
                || semente == "999999999"
            );

            for (int i = 1; i < multiplicadores.Count(); i++)
                soma += int.Parse(semente[i - 1].ToString()) * multiplicadores[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente += resto;
            soma = 0;

            for (int i = 0; i < multiplicadores.Count(); i++)
                soma += int.Parse(semente[i].ToString()) * multiplicadores[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;

            return semente;
        }
        public static string RandomNames()
        {
            var random = new Random();
            var nomes = new[] {
                "Ana Maria",
                "Ana Clara",
                "Ana Gabriela",
                "Amanda",
                "Arthur",
                "Alex",
                "Bruna",
                "Bruno",
                "Bárbara",
                "Beatriz",
                "Carla",
                "Carlos Alberto",
                "Carlos Eduardo",
                "Cristina",
                "Danilo",
                "Daniela",
                "Daniele",
                "Daniel",
                "Denize",
                "Eduardo",
                "Eduarda",
                "Elizabete",
                "Francisca",
                "Francine",
                "Fernando",
                "Fernanda",
                "Gabriel",
                "Gabriela",
                "Giovana",
                "Giovane",
                "Hugo",
                "Hélio",
                "Israel",
                "Israelita",
                "João Carlos",
                "João Marcelo",
                "João Augusto",
                "João Guilherme",
                "Luiz Ricardo",
                "Luiz Roberto",
                "Luiza Maria",
                "Luiza",
                "Letícia",
                "Letícia Maria",
                "Marcelo",
                "Marcel",
                "Marcela",
                "Maria",
                "Maria José",
                "Maria Eduarda",
                "Nilma",
                "Nadir",
                "Noelma",
                "Otávio",
                "Otilia",
                "Osvaldo",
                "Pedro",
                "Paulo",
                "Patrícia",
                "Paloma",
                "Rafeal",
                "Raimundo",
                "Rodrigo",
                "Renata",
                "Renato",
                "Silvia",
                "Silvio",
                "Sandra",
                "Severino",
                "Severino José",
                "Shirley",
                "Sabrina",
                "Tácio",
                "Tiago",
                "Talita",
                "Tereza",
                "Vitória",
                "Vinicios",
                "Valter",
                "Valeria"
            };
            var sobrenomes = new[] {
                "Alves",
                "Braga",
                "da Silva",
                "Dantas",
                "Vieira",
                "da Luz",
                "Magalhães",
                "Barbosa",
                "Pereira",
                "Lima",
                "Monteiro",
                "Rezende",
                "Souza",
                "Cruz",
                "Vilaça",
                "Brasil",
                "Laranjeira",
                "Brizola",
                "Gomes",
                "Cavalcanti",
                "Pessoa",
                "Silverio",
                "Espirito Santo",
                "Medeiros",
                "Araújo",
                "Albuquerque",
                "Ferreira",
                "Garcia"
            };

            return nomes[random.Next(nomes.Length)] + " " + sobrenomes[random.Next(sobrenomes.Length)] + " " + sobrenomes[random.Next(sobrenomes.Length)];
        }
    }
}
