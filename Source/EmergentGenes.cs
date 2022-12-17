using RimWorld;
using Verse;
using HarmonyLib;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using Verse.AI;
using UnityEngine.Assertions.Must;
using static System.Net.Mime.MediaTypeNames;

namespace EmergentGenes
{
    [StaticConstructorOnStartup]
    public static class emergentGeneDef
    {

        static emergentGeneDef()
        {
            var harmony = new Harmony("eg.inertav.patch");
            harmony.PatchAll();


        }

    }
    public class EmergentGeneModExtension : DefModExtension
    {
        public List<GeneDef> GenePrerequisite;
        public List<string> GeneShare;
        public List<string> GeneTag;
        public List<GeneDef> GeneExclusion;
        public bool HiddenGene;
    }
    [HarmonyPatch(typeof(Dialog_CreateXenotype), "GeneTip")]
    public static class GeneTipEmergent
    {
        public static void Postfix(GeneDef geneDef, bool selectedSection, List<GeneDef> ___selectedGenes, ref string __result)
        {
            if (___selectedGenes.Contains(geneDef) && (geneDef?.HasModExtension<EmergentGeneModExtension>() ?? true))
            {
                if (!__result.NullOrEmpty())
                {
                    __result += "\n\n";
                }
                __result += ("i am beppin");
                return;
            }
        }
    }
    [HarmonyPatch(typeof(Dialog_CreateXenotype), "SelectedGenes", MethodType.Getter)]
    public static class GeneTipEmergenttesttest
    {
        public static void Postfix(List<GeneDef> ___selectedGenes)
        {
            List<GeneDef> testing = DefDatabase<GeneDef>.AllDefsListForReading;
            foreach (GeneDef geneDef1 in testing)
            {
                /*if (geneDef1?.GetModExtension<EmergentGeneModExtension>()?.GeneTag != null)
                {
                    List<string> list = geneDef1?.GetModExtension<EmergentGeneModExtension>()?.GeneTag;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] == "thorium")
                        {
                            Log.Message(list[i]);
                        }
                    }
                }*/
                /*if (___selectedGenes?.Any(i => i.GetModExtension<EmergentGeneModExtension>()?.GeneTag == geneDef1?.GetModExtension<EmergentGeneModExtension>()?.GeneShare) ?? false)
                {
                    //Log.Message("i am working");
                    if (geneDef1.defName == "WoundHealing_psychic_brolotes")
                    {
                        Log.Message("slap my ass");
                    }
                }*/
                /*if (___selectedGenes?.Any(i => i.GetModExtension<EmergentGeneModExtension>()?.GeneTag?.Any(q =>  geneDef1?.GetModExtension<EmergentGeneModExtension>()?.GeneShare?.Contains(q) ?? false) ?? false) ?? false)
                {
                    //Log.Message("i am working");
                    if (geneDef1.defName == "WoundHealing_psychic_brolotes")
                    {
                        Log.Message("slap my ass");
                    }
                }*/
                /*if (testing?.Any(i => i.GetModExtension<EmergentGeneModExtension>()?.GeneShare == geneDef1?.GetModExtension<EmergentGeneModExtension>()?.GeneTag) ?? false)
                {
                    //Log.Message("i am working");
                    if (geneDef1.defName == "WoundHealing_psychic_brolotes")
                    {
                        Log.Message("slap my ass");
                    }
                }*/
                if ((geneDef1?.GetModExtension<EmergentGeneModExtension>()?.GenePrerequisite?.TrueForAll(gd => ___selectedGenes.Contains(gd)) ?? false) || (___selectedGenes?.Any(i => i.GetModExtension<EmergentGeneModExtension>()?.GeneTag?.Any(q => geneDef1?.GetModExtension<EmergentGeneModExtension>()?.GeneShare?.Contains(q) ?? false) ?? false) ?? false))
                {
                    if (geneDef1.defName == "WoundHealing_psychic_brolotes")
                    {
                        Log.Message("oh captain lets make a deal");
                    }
                    if (!___selectedGenes.Contains(geneDef1) && (!geneDef1?.GetModExtension<EmergentGeneModExtension>()?.GeneExclusion?.Any(gd => ___selectedGenes.Contains(gd)) ?? true) && (geneDef1?.HasModExtension<EmergentGeneModExtension>() ?? false) && ((geneDef1.GetModExtension<EmergentGeneModExtension>().GenePrerequisite != null) || (geneDef1.GetModExtension<EmergentGeneModExtension>().GeneShare != null)))
                    {
                        //Log.Message(geneDef1.defName);
                        ___selectedGenes.Add(geneDef1);
                    }
                    if (___selectedGenes.Contains(geneDef1) && (geneDef1?.GetModExtension<EmergentGeneModExtension>()?.GeneExclusion?.Any(gd => ___selectedGenes.Contains(gd)) ?? false))
                    {
                        ___selectedGenes.Remove(geneDef1);
                        Messages.Message("DoNotHaveRequirements", null, MessageTypeDefOf.RejectInput, historical: false);
                    }
                }
                Log.Message((!___selectedGenes?.Any(i => i.GetModExtension<EmergentGeneModExtension>()?.GeneTag?.Any(q => geneDef1?.GetModExtension<EmergentGeneModExtension>()?.GeneShare?.Contains(q) ?? false) ?? false) ?? false).ToString());
                if ((!geneDef1?.GetModExtension<EmergentGeneModExtension>()?.GenePrerequisite?.TrueForAll(gd => ___selectedGenes.Contains(gd)) ?? false) || ((geneDef1?.GetModExtension<EmergentGeneModExtension>()?.GeneShare != null)) && (!___selectedGenes?.Any(i => i.GetModExtension<EmergentGeneModExtension>()?.GeneTag?.Any(q => geneDef1?.GetModExtension<EmergentGeneModExtension>()?.GeneShare?.Contains(q) ?? false) ?? false) ?? false))
                {
                    if (geneDef1.defName == "WoundHealing_psychic_brolotes")
                    {
                        Log.Message("oh captain lets not make a deal");
                    }
                    if (___selectedGenes.Contains(geneDef1) && (geneDef1?.GetModExtension<EmergentGeneModExtension>()?.GeneExclusion?.Any(gd => ___selectedGenes.Contains(gd)) ?? true))
                    {
                        ___selectedGenes.Remove(geneDef1);
                        Messages.Message("DoNotHaveRequirements", null, MessageTypeDefOf.RejectInput, historical: false);
                    }
                    if (___selectedGenes.Contains(geneDef1) && (!geneDef1?.GetModExtension<EmergentGeneModExtension>()?.GeneExclusion?.Any(gd => ___selectedGenes.Contains(gd)) ?? false))
                    {
                        ___selectedGenes.Remove(geneDef1);
                        Messages.Message("DoNotHaveRequirements", null, MessageTypeDefOf.RejectInput, historical: false);
                    }
                }
            }

        }
        /*public static void Postfix(List<GeneDef> ___selectedGenes)
        {
            List<GeneDef> testing = DefDatabase<GeneDef>.AllDefsListForReading;
            foreach (GeneDef geneDef1 in testing)
            {
                if (geneDef1?.GetModExtension<EmergentGeneModExtension>()?.GenePrerequisite?.TrueForAll(gd => ___selectedGenes.Contains(gd)) ?? true)
                {
                    if (!___selectedGenes.Contains(geneDef1) && (!geneDef1?.GetModExtension<EmergentGeneModExtension>()?.GeneExclusion?.Any(gd => ___selectedGenes.Contains(gd)) ?? true) && (geneDef1?.HasModExtension<EmergentGeneModExtension>() ?? false) && (geneDef1.GetModExtension<EmergentGeneModExtension>().GenePrerequisite != null))
                    {
                        Log.Message(geneDef1.ToString() + " was added");
                        ___selectedGenes.Add(geneDef1);
                    }
                    if (___selectedGenes.Contains(geneDef1) && (geneDef1?.GetModExtension<EmergentGeneModExtension>()?.GeneExclusion?.Any(gd => ___selectedGenes.Contains(gd)) ?? false))
                    {
                        Log.Message(geneDef1.ToString() + " was removed");
                        ___selectedGenes.Remove(geneDef1);
                        Messages.Message("DoNotHaveRequirements", null, MessageTypeDefOf.RejectInput, historical: false);
                    }
                }
                if (!geneDef1?.GetModExtension<EmergentGeneModExtension>()?.GenePrerequisite?.TrueForAll(gd => ___selectedGenes.Contains(gd)) ?? false)
                {
                    if (___selectedGenes.Contains(geneDef1) && (geneDef1?.GetModExtension<EmergentGeneModExtension>()?.GeneExclusion?.Any(gd => ___selectedGenes.Contains(gd)) ?? true))
                    {
                        ___selectedGenes.Remove(geneDef1);
                        Messages.Message("DoNotHaveRequirements", null, MessageTypeDefOf.RejectInput, historical: false);
                    }
                    if (___selectedGenes.Contains(geneDef1) && (!geneDef1?.GetModExtension<EmergentGeneModExtension>()?.GeneExclusion?.Any(gd => ___selectedGenes.Contains(gd)) ?? false))
                    {
                        Log.Message(geneDef1.ToString() + " was removed");
                        ___selectedGenes.Remove(geneDef1);
                        Messages.Message("DoNotHaveRequirements", null, MessageTypeDefOf.RejectInput, historical: false);
                    }
                }
            }

        }*/
    }
    [HarmonyPatch(typeof(Dialog_CreateXenogerm), "SelectedGenes", MethodType.Getter)]
    public static class GeneTipEmergenttesttesttest
    {
        public static void Postfix(List<Genepack> ___selectedGenepacks, ref List<GeneDef> __result)
        {
            List<GeneDef> testing = DefDatabase<GeneDef>.AllDefsListForReading;
            /*HashSet<GeneDef> GenepackSet = new HashSet<GeneDef>(__result);
            HashSet<GeneDef> GenepackTempSet = new HashSet<GeneDef>(testing);*/
            List<GeneDef> selectgenes = __result;
            Genepack thor1 = (Genepack)ThingMaker.MakeThing(ThingDefOf.Genepack);
            List<GeneDef> genesToAdd = new List<GeneDef>();
            foreach (GeneDef geneDef1 in testing)
            {
                /*GenepackSet.ToList<GeneDef>().ForEach(x => Log.Message(x.ToString()));
                GenepackTempSet.ToList<GeneDef>().ForEach(x => Log.Message(x.ToString()));*/
                if (geneDef1.HasModExtension<EmergentGeneModExtension>() && (geneDef1?.GetModExtension<EmergentGeneModExtension>()?.GenePrerequisite?.TrueForAll(gd => selectgenes.Contains(gd)) ?? false) || (selectgenes?.Any(i => i.GetModExtension<EmergentGeneModExtension>()?.GeneTag?.Any(q => geneDef1?.GetModExtension<EmergentGeneModExtension>()?.GeneShare?.Contains(q) ?? false) ?? false) ?? false))
                {
                    //GenepackTempSet.Add();
                    /*foreach (GeneDef test in GenepackTempSet)
                    {
                        Log.Message(test.GetModExtension<EmergentGeneModExtension>().GenePrerequisite.ToString());
                    }*/
                    genesToAdd.Add(geneDef1);
                    thor1.Initialize(genesToAdd);
                    genesToAdd.Clear();
                    if (!selectgenes.Contains(geneDef1))
                    {
                        /*for (int i = thor1.GeneSet.GenesListForReading.Count - 1; i >= 0; i--)
                        {
                            thor1.GeneSet.Debug_RemoveGene(thor1.GeneSet.GenesListForReading[i]);
                        }*/
                        //thor1.GeneSet.AddGene(test);
                        ___selectedGenepacks.Add(thor1);
                    }
                }
                if (selectgenes.Contains(geneDef1) && (!geneDef1?.GetModExtension<EmergentGeneModExtension>()?.GenePrerequisite?.All(gd => selectgenes.Contains(gd)) ?? false) || ((!geneDef1?.GetModExtension<EmergentGeneModExtension>()?.GeneShare.NullOrEmpty()) ?? false) && (!selectgenes?.Any(i => i.GetModExtension<EmergentGeneModExtension>()?.GeneTag?.Any(q => geneDef1?.GetModExtension<EmergentGeneModExtension>()?.GeneShare?.Contains(q) ?? false) ?? false) ?? false))
                {
                    Log.Message("i should get removed");
                    /*foreach (Genepack v in ___selectedGenepacks)
                    {
                        Log.Message("about to remove");


                    }*/
                    /*for (int i = ___selectedGenepacks.Count - 1; i >= 0; i--)
                    {
                        foreach (GeneDef testerer in __result)
                        {

                        }

                        GeneDef thump = selectgenes[i];
                        List<Genepack> test = new List<Genepack>();
                        Log.Message(test.ToString());
                        Log.Message(geneDef1?.GetModExtension<EmergentGeneModExtension>()?.GenePrerequisite?.Count.ToString());
                        Log.Message(thump?.GetModExtension<EmergentGeneModExtension>()?.GenePrerequisite?.Count.ToString());
                        if ((thump?.GetModExtension<EmergentGeneModExtension>()?.GenePrerequisite?.NullOrEmpty() == false) && (geneDef1?.GetModExtension<EmergentGeneModExtension>()?.GenePrerequisite?.NullOrEmpty() == false) && (geneDef1?.GetModExtension<EmergentGeneModExtension>()?.GenePrerequisite?.TrueForAll(gd => selectgenes.Contains(gd)) ?? false) && (geneDef1.GetModExtension<EmergentGeneModExtension>().GenePrerequisite?.Count != thump.GetModExtension<EmergentGeneModExtension>().GenePrerequisite.Count))
                        {
                            Log.Message("removed " + ___selectedGenepacks[i].ToString());
                            ___selectedGenepacks.Remove(___selectedGenepacks[i]);
                        }
                    }*/
                    for (int i = ___selectedGenepacks.Count - 1; i >= 0; i--)
                    {
                        Genepack genepacksSelected = ___selectedGenepacks[i];
                        for (int j = genepacksSelected.GeneSet.GenesListForReading.Count - 1; j >= 0; j--)
                        {
                            /*if (!genepacksSelected.GeneSet?.GenesListForReading[j]?.GetModExtension<EmergentGeneModExtension>()?.GeneShare?.Any(gd => selectgenes.Any(p => p.GetModExtension<EmergentGeneModExtension>()?.GeneTag?.Contains(gd) ?? false)) ?? false)
                            {
                                Log.Message("ians a bitch");
                            }*/
                            if ((!genepacksSelected.GeneSet?.GenesListForReading[j].GetModExtension<EmergentGeneModExtension>()?.GeneShare.NullOrEmpty() ?? false) || (!genepacksSelected.GeneSet?.GenesListForReading[j].GetModExtension<EmergentGeneModExtension>()?.GeneTag.NullOrEmpty() ?? false) && ((!genepacksSelected.GeneSet?.GenesListForReading[j]?.GetModExtension<EmergentGeneModExtension>()?.GenePrerequisite.All(gd => selectgenes.Contains(gd)) ?? false) || (!genepacksSelected.GeneSet?.GenesListForReading[j]?.GetModExtension<EmergentGeneModExtension>()?.GeneShare?.Any(gd => selectgenes.Any(p => p.GetModExtension<EmergentGeneModExtension>()?.GeneTag?.Contains(gd) ?? false)) ?? false)))
                            {
                                Log.Message("removed " + ___selectedGenepacks[i].ToString());
                                ___selectedGenepacks.Remove(___selectedGenepacks[i]);
                            }
                        }
                    }

                }


            }

        }
    }
    /*[HarmonyPatch(typeof(GeneUtility), "GeneSet GenerateGeneSet")]
    public static class GenepackExcluderPatch
    {
        public static void Postfix(int? ___seed = null)
        {
            Log.Message("testingtesting");
        }
    }*/

    [HarmonyPatch(typeof(GeneSet), "CanAddGeneDuringGeneration")]
    public static class GenepackExcluderPatch
    {
        public static void Postfix(GeneDef gene, ref bool __result)
        {
            if (gene.GetModExtension<EmergentGeneModExtension>()?.HiddenGene ?? false)
            {
                Log.Message("i prevented");
                __result = false;
            }
        }
    }
    /*[HarmonyPatch(typeof(Genepack), "Initialize")]
    public static class GenepackExcluderPatch
    {
        public static void Prefix(List<GeneDef> genes, GeneSet ___geneSet)
        {
            ___geneSet = new GeneSet();
            foreach (GeneDef gene in genes)
            {
                Log.Message("i have been curved and swerved and most of all, perturbed");
                if (gene.GetModExtension<EmergentGeneModExtension>()?.HiddenGene ?? false && gene.GetModExtension<EmergentGeneModExtension>().HiddenGene)
                {
                    Log.Message("i have been curved and swerved and most of all, perturbed");
                }
                else
                {
                    ___geneSet.AddGene(gene);
                }
            }
        }
    }*/
    /*[HarmonyPatch(typeof(Genepack), "Initialize")]
    public static class GenepackExcluderPatch
    {
        public static void Postfix(List<GeneDef> genes, GeneSet ___geneSet)
        {
                Log.Message("i have been curved and swerved and most of all, perturbed");
        }
    }*/
}
/*List<Genepack> bro = new List<Genepack>();
List<GeneSet> alt = new List<GeneSet>();*/
//geneDef1.GeneSet.GenesListForReading
//Genepack genepack = (Genepack)ThingMaker.MakeThing(ThingDefOf.Genepack);
//bro.Add(geneDef1);
//___selectedGenepacks.Add(geneDef1);
//___selectedGenepacks.Add(alt);
/*Log.Message(__result.ToString());
geneSet = new GeneSet();
foreach (GeneDef gene in genes)
{
    geneSet.AddGene(gene);
}*/
