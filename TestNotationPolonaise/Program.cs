/**
 * Application de test de la fonction 'Polonaise'
 * author : Emds
 * date : 20/06/2020
 */
using System;

namespace TestNotationPolonaise
{
    class Program
    {
        static float Polonaise(string formule)
        {
            try
            {
                // Transformation de la formule en vecteur
                string[] elements = formule.Split(' ');
                int nbCases = elements.Length;

                // Boucle tant qu'il y a plus d'une case
                while (nbCases > 1)
                {
                    // Recherche d'un signe à partir de la fin
                    int k = nbCases - 1;
                    while (elements[k] != "+" && elements[k] != "-" && elements[k] != "*" && elements[k] != "/")
                    {
                        k--;
                    }

                    // Récupération des deux valeurs concernés par le calcul
                    float nb1 = float.Parse(elements[k + 1]);
                    float nb2 = float.Parse(elements[k + 2]);

                    // Calcul
                    float resultat = 0;
                    switch (elements[k])
                    {
                        case "+": resultat = nb1 + nb2; break;
                        case "-": resultat = nb1 - nb2; break;
                        case "*": resultat = nb1 * nb2; break;
                        case "/":
                            // Eviter la division par 0
                            if (nb2 == 0)
                            {
                                return float.NaN;
                            }
                            resultat = nb1 / nb2; break;
                    }
                    // Stockage du résultat à la place du signe
                    elements[k] = resultat.ToString();

                    // Suppression des valeurs suivantes par le décalage vers la gauche
                    for (int j = k + 1; j < nbCases - 2; j++)
                    {
                        elements[j] = elements[j + 2];
                    }

                    // Remplacement des deux dernières cases par un espace
                    for (int j = nbCases - 2; j < nbCases; j++)
                    {
                        elements[j] = " ";
                    }
                    nbCases = nbCases - 2;
                }
                return (float.Parse(elements[0]));
            }
            catch
            {
                // Erreur rencontrée
                return float.NaN;
            }
        }
        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }

        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                string laFormule = Console.ReadLine();
                // affichage du résultat
                Console.WriteLine("Résultat =  " + Polonaise(laFormule));
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
    }
}
