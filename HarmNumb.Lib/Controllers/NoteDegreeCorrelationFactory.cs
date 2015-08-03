using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmNumb.Models;

namespace HarmNumb.Controllers
{
    public class NoteDegreeCorrelationFactory
    {
        public static List<NoteDegreeCorrelation> GetCorrelationsForKey(string key)
        {
            var correlations = new List<NoteDegreeCorrelation>();

            switch(key)
            {
                case "C":
                    CreateCorrelationsForKeyC(correlations);
                    break;
                case "G":
                    CreateCorrelationsForKeyG(correlations);
                    break;
                case "D":
                    CreateCorrelationsForKeyD(correlations);
                    break;
                case "A":
                    CreateCorrelationsForKeyA(correlations);
                    break;
                case "E":
                    CreateCorrelationsForKeyE(correlations);
                    break;
                case "B":
                    CreateCorrelationsForKeyB(correlations);
                    break;
                case "F#":
                    CreateCorrelationsForKeyFSharp(correlations);
                    break;
                case "F":
                    CreateCorrelationsForKeyF(correlations);
                    break;
                case "Bb":
                    CreateCorrelationsForKeyBb(correlations);
                    break;
                case "Eb":
                    CreateCorrelationsForKeyEb(correlations);
                    break;
                case "Ab":
                    CreateCorrelationsForKeyAb(correlations);
                    break;
                case "Db":
                    CreateCorrelationsForKeyDb(correlations);
                    break;
                case "Gb":
                    CreateCorrelationsForKeyGb(correlations);
                    break;

            }

            return correlations;
        }

        private static void CreateCorrelationsForKeyC(List<NoteDegreeCorrelation> correlations)
        {
            correlations.Add(new NoteDegreeCorrelation("C", "C", 1));
            correlations.Add(new NoteDegreeCorrelation("C", "D", 2));
            correlations.Add(new NoteDegreeCorrelation("C", "E", 3));
            correlations.Add(new NoteDegreeCorrelation("C", "F", 4));
            correlations.Add(new NoteDegreeCorrelation("C", "G", 5));
            correlations.Add(new NoteDegreeCorrelation("C", "A", 6));
            correlations.Add(new NoteDegreeCorrelation("C", "B", 7));
        }

        private static void CreateCorrelationsForKeyG(List<NoteDegreeCorrelation> correlations)
        {
            correlations.Add(new NoteDegreeCorrelation("G", "G", 1));
            correlations.Add(new NoteDegreeCorrelation("G", "A", 2));
            correlations.Add(new NoteDegreeCorrelation("G", "B", 3));
            correlations.Add(new NoteDegreeCorrelation("G", "C", 4));
            correlations.Add(new NoteDegreeCorrelation("G", "D", 5));
            correlations.Add(new NoteDegreeCorrelation("G", "E", 6));
            correlations.Add(new NoteDegreeCorrelation("G", "F#", 7));
        }

        private static void CreateCorrelationsForKeyD(List<NoteDegreeCorrelation> correlations)
        {
            correlations.Add(new NoteDegreeCorrelation("D", "D", 1));
            correlations.Add(new NoteDegreeCorrelation("D", "E", 2));
            correlations.Add(new NoteDegreeCorrelation("D", "F#", 3));
            correlations.Add(new NoteDegreeCorrelation("D", "G", 4));
            correlations.Add(new NoteDegreeCorrelation("D", "A", 5));
            correlations.Add(new NoteDegreeCorrelation("D", "B", 6));
            correlations.Add(new NoteDegreeCorrelation("D", "C#", 7));
        }

        private static void CreateCorrelationsForKeyA(List<NoteDegreeCorrelation> correlations)
        {
            correlations.Add(new NoteDegreeCorrelation("A", "A", 1));
            correlations.Add(new NoteDegreeCorrelation("A", "B", 2));
            correlations.Add(new NoteDegreeCorrelation("A", "C#", 3));
            correlations.Add(new NoteDegreeCorrelation("A", "D", 4));
            correlations.Add(new NoteDegreeCorrelation("A", "E", 5));
            correlations.Add(new NoteDegreeCorrelation("A", "F#", 6));
            correlations.Add(new NoteDegreeCorrelation("A", "G#", 7));
        }

        private static void CreateCorrelationsForKeyE(List<NoteDegreeCorrelation> correlations)
        {
            correlations.Add(new NoteDegreeCorrelation("E", "E", 1));
            correlations.Add(new NoteDegreeCorrelation("E", "F#", 2));
            correlations.Add(new NoteDegreeCorrelation("E", "G#", 3));
            correlations.Add(new NoteDegreeCorrelation("E", "A", 4));
            correlations.Add(new NoteDegreeCorrelation("E", "B", 5));
            correlations.Add(new NoteDegreeCorrelation("E", "C#", 6));
            correlations.Add(new NoteDegreeCorrelation("E", "D#", 7));
        }


        private static void CreateCorrelationsForKeyB(List<NoteDegreeCorrelation> correlations)
        {
            correlations.Add(new NoteDegreeCorrelation("B", "B", 1));
            correlations.Add(new NoteDegreeCorrelation("B", "C#", 2));
            correlations.Add(new NoteDegreeCorrelation("B", "D#", 3));
            correlations.Add(new NoteDegreeCorrelation("B", "E", 4));
            correlations.Add(new NoteDegreeCorrelation("B", "F#", 5));
            correlations.Add(new NoteDegreeCorrelation("B", "G#", 6));
            correlations.Add(new NoteDegreeCorrelation("B", "A#", 7));
        }


        private static void CreateCorrelationsForKeyFSharp(List<NoteDegreeCorrelation> correlations)
        {
            correlations.Add(new NoteDegreeCorrelation("F#", "F#", 1));
            correlations.Add(new NoteDegreeCorrelation("F#", "G#", 2));
            correlations.Add(new NoteDegreeCorrelation("F#", "A#", 3));
            correlations.Add(new NoteDegreeCorrelation("F#", "B", 4));
            correlations.Add(new NoteDegreeCorrelation("F#", "C#", 5));
            correlations.Add(new NoteDegreeCorrelation("F#", "D#", 6));
            correlations.Add(new NoteDegreeCorrelation("F#", "E#", 7));
        }

        private static void CreateCorrelationsForKeyF(List<NoteDegreeCorrelation> correlations)
        {
            correlations.Add(new NoteDegreeCorrelation("F", "F", 1));
            correlations.Add(new NoteDegreeCorrelation("F", "G", 2));
            correlations.Add(new NoteDegreeCorrelation("F", "A", 3));
            correlations.Add(new NoteDegreeCorrelation("F", "Bb", 4));
            correlations.Add(new NoteDegreeCorrelation("F", "C", 5));
            correlations.Add(new NoteDegreeCorrelation("F", "D", 6));
            correlations.Add(new NoteDegreeCorrelation("F", "E", 7));
        }

        private static void CreateCorrelationsForKeyBb(List<NoteDegreeCorrelation> correlations)
        {
            correlations.Add(new NoteDegreeCorrelation("Bb", "Bb", 1));
            correlations.Add(new NoteDegreeCorrelation("Bb", "C", 2));
            correlations.Add(new NoteDegreeCorrelation("Bb", "D", 3));
            correlations.Add(new NoteDegreeCorrelation("Bb", "Eb", 4));
            correlations.Add(new NoteDegreeCorrelation("Bb", "F", 5));
            correlations.Add(new NoteDegreeCorrelation("Bb", "G", 6));
            correlations.Add(new NoteDegreeCorrelation("Bb", "A", 7));
        }

        private static void CreateCorrelationsForKeyEb(List<NoteDegreeCorrelation> correlations)
        {
            correlations.Add(new NoteDegreeCorrelation("Eb", "Eb", 1));
            correlations.Add(new NoteDegreeCorrelation("Eb", "F", 2));
            correlations.Add(new NoteDegreeCorrelation("Eb", "G", 3));
            correlations.Add(new NoteDegreeCorrelation("Eb", "Ab", 4));
            correlations.Add(new NoteDegreeCorrelation("Eb", "Bb", 5));
            correlations.Add(new NoteDegreeCorrelation("Eb", "C", 6));
            correlations.Add(new NoteDegreeCorrelation("Eb", "D", 7));
        }

        private static void CreateCorrelationsForKeyAb(List<NoteDegreeCorrelation> correlations)
        {
            correlations.Add(new NoteDegreeCorrelation("Ab", "Bb", 1));
            correlations.Add(new NoteDegreeCorrelation("Ab", "C", 2));
            correlations.Add(new NoteDegreeCorrelation("Ab", "Db", 3));
            correlations.Add(new NoteDegreeCorrelation("Ab", "Eb", 4));
            correlations.Add(new NoteDegreeCorrelation("Ab", "F", 5));
            correlations.Add(new NoteDegreeCorrelation("Ab", "G", 6));
            correlations.Add(new NoteDegreeCorrelation("Ab", "Ab", 7));
        }

        private static void CreateCorrelationsForKeyDb(List<NoteDegreeCorrelation> correlations)
        {
            correlations.Add(new NoteDegreeCorrelation("Db", "Db", 1));
            correlations.Add(new NoteDegreeCorrelation("Db", "Eb", 2));
            correlations.Add(new NoteDegreeCorrelation("Db", "F", 3));
            correlations.Add(new NoteDegreeCorrelation("Db", "Gb", 4));
            correlations.Add(new NoteDegreeCorrelation("Db", "Ab", 5));
            correlations.Add(new NoteDegreeCorrelation("Db", "Bb", 6));
            correlations.Add(new NoteDegreeCorrelation("Db", "C", 7));
        }

        private static void CreateCorrelationsForKeyGb(List<NoteDegreeCorrelation> correlations)
        {
            correlations.Add(new NoteDegreeCorrelation("Gb", "Gb", 1));
            correlations.Add(new NoteDegreeCorrelation("Gb", "Ab", 2));
            correlations.Add(new NoteDegreeCorrelation("Gb", "Bb", 3));
            correlations.Add(new NoteDegreeCorrelation("Gb", "Cb", 4));
            correlations.Add(new NoteDegreeCorrelation("Gb", "Db", 5));
            correlations.Add(new NoteDegreeCorrelation("Gb", "Eb", 6));
            correlations.Add(new NoteDegreeCorrelation("Gb", "F", 7));
        }
    }
}