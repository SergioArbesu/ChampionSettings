﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionSettingsClassLibrary
{
    public static class IdDictionaries
    {
        public static readonly Dictionary<string, int> champDict = new Dictionary<string, int>()
        {
            {"Aatrox", 266}, {"Ahri", 103}, {"Akali", 84}, {"Akshan", 166}, {"Alistar", 12}, {"Amumu", 32}, {"Anivia", 34},
            {"Annie", 1}, {"Aphelios", 523}, {"Ashe", 22}, {"Aurelion Sol", 136}, {"Azir", 268}, {"Bard", 432}, {"Blitzcrank", 53},
            {"Brand", 63}, {"Braum", 201}, {"Caitlyn", 51}, {"Camille", 164}, {"Cassiopeia", 69}, {"Cho'Gath", 31}, {"Corki", 42},
            {"Darius", 122}, {"Diana", 131}, {"Dr. Mundo", 119}, {"Draven", 36}, {"Ekko", 245}, {"Elise", 60}, {"Evelynn", 28},
            {"Ezreal", 81}, {"Fiddlesticks", 9}, {"Fiora", 114}, {"Fizz", 105}, {"Galio", 3}, {"Gangplank", 41}, {"Garen", 86},
            {"Gnar", 150}, {"Gragas", 79}, {"Graves", 104}, {"Gwen", 887}, {"Hecarim", 120}, {"Heimerdinger", 74}, {"Illaoi", 420},
            {"Irelia", 39}, {"Ivern", 427}, {"Janna", 40}, {"Jarvan IV", 59}, {"Jax", 24}, {"Jayce", 126}, {"Jhin", 202}, {"Jinx", 222},
            {"Kai'Sa", 145}, {"Kalista", 429}, {"Karma", 43}, {"Karthus", 30}, {"Kassadin", 38}, {"Katarina", 55}, {"Kayle", 10},
            {"Kayn", 141}, {"Kennen", 85}, {"Kha'Zix", 121}, {"Kindred", 203}, {"Kled", 240}, {"Kog'Maw", 96}, {"LeBlanc", 7},
            {"Lee Sin", 64}, {"Leona", 89}, {"Lillia", 876}, {"Lissandra", 127}, {"Lucian", 236}, {"Lulu", 117}, {"Lux", 99},
            {"Malphite", 54}, {"Malzahar", 90}, {"Maokai", 57}, {"Master Yi", 11}, {"Miss Fortune", 21}, {"Mordekaiser", 82},
            {"Morgana", 25}, {"Nami", 267}, {"Nasus", 75}, {"Nautilus", 111}, {"Neeko", 518}, {"Nidalee", 76}, {"Nocturne", 56},
            {"Nunu & Willump", 20}, {"Olaf", 2}, {"Orianna", 61}, {"Ornn", 516}, {"Pantheon", 80}, {"Poppy", 78}, {"Pyke", 555},
            {"Qiyana", 246}, {"Quinn", 133}, {"Rakan", 497}, {"Rammus", 33}, {"Rek'Sai", 421}, {"Rell", 526}, {"Renata Glasc", 888},
            {"Renekton", 58}, {"Rengar", 107}, {"Riven", 92}, {"Rumble", 68}, {"Ryze", 13}, {"Samira", 360}, {"Sejuani", 113},
            {"Senna", 235}, {"Seraphine", 147}, {"Sett", 875}, {"Shaco", 35}, {"Shen", 98}, {"Shyvana", 102}, {"Singed", 27},
            {"Sion", 14}, {"Sivir", 15}, {"Skarner", 72}, {"Sona", 37}, {"Soraka", 16}, {"Swain", 50}, {"Sylas", 517}, {"Syndra", 134},
            {"Tahm Kench", 223}, {"Taliyah", 163}, {"Talon", 91}, {"Taric", 44}, {"Teemo", 17}, {"Thresh", 412}, {"Tristana", 18},
            {"Trundle", 48}, {"Tryndamere", 23}, {"Twisted Fate", 4}, {"Twitch", 29}, {"Udyr", 77}, {"Urgot", 6}, {"Varus", 110},
            {"Vayne", 67}, {"Veigar", 45}, {"Vel'Koz", 161}, {"Vex", 711}, {"Vi", 254}, {"Viego", 234}, {"Viktor", 112},
            {"Vladimir", 8}, {"Volibear", 106}, {"Warwick", 19}, {"Wukong", 62}, {"Xayah", 498}, {"Xerath", 101}, {"Xin Zhao", 5},
            {"Yasuo", 157}, {"Yone", 777}, {"Yorick", 83}, {"Yuumi", 350}, {"Zac", 154}, {"Zed", 238}, {"Zeri", 221}, {"Ziggs", 115},
            {"Zilean", 26}, {"Zoe", 142}, {"Zyra", 143}, {"Nilah", 895}, {"Bel'Veth", 200}, {"K'Sante", 897}, {"Milio", 902}
        };
        public static readonly Dictionary<string, int> styleDict = new Dictionary<string, int>()
        {
            {"Precision", 8000}, {"Dominance", 8100}, {"Sorcery", 8200}, {"Resolve", 8400}, {"Inspiration", 8300}
        };
        public static readonly Dictionary<string, int> perkDict = new Dictionary<string, int>()
        {
            {"Press the Attack", 8005 }, {"Lethal Tempo", 8008}, {"Fleet Footwork", 8021}, {"Conqueror", 8010},
            {"Overheal", 9101}, {"Triumph", 9111}, {"Presence of Mind", 8009},
            {"Legend: Alacrity", 9104}, {"Legend: Tenacity", 9105}, {"Legend: Bloodline", 9103},
            {"Coup de Grace", 8014},{"Cut Down", 8017}, {"Last Stand", 8299},
            {"Electrocute", 8112}, {"Predator", 8124}, {"Dark Harvest", 8128}, {"Hail of Blades", 9923},
            {"Cheap Shot", 8126}, {"Taste of Blood", 8139}, {"Sudden Impact", 8143},
            {"Zombie Ward", 8136}, {"Ghost Poro", 8120}, {"Eyeball Collection", 8138},
            {"Treasure Hunter", 8135}, {"Ingenious Hunter", 8134}, {"Relentless Hunter", 8105}, {"Ultimate Hunter", 8106},
            {"Summon Aery", 8214}, {"Arcane Comet", 8229}, {"Phase Rush", 8230},
            {"Nullifying Orb", 8224}, {"Manaflow Band", 8226}, {"Nimbus Cloak", 8275},
            {"Transcendence", 8210}, {"Celerity", 8234}, {"Absolute Focus", 8233},
            {"Scorch", 8237}, {"Waterwalking", 8232}, {"Gathering Storm", 8236},
            {"Grasp of the Undying", 8437}, {"Aftershock", 8439}, {"Guardian", 8465},
            {"Demolish", 8446}, {"Font of Life", 8463}, {"Shield Bash", 8401},
            {"Conditioning", 8429}, {"Second Wind", 8444}, {"Bone Plating", 8473},
            {"Overgrowth", 8451}, {"Revitalize", 8453}, {"Unflinching", 8242},
            {"Glacial Augment", 8351}, {"Unsealed Spellbook", 8360}, {"First Strike", 8369},
            {"Hextech Flashtraption", 8306}, {"Magical Footwear", 8304}, {"Perfect Timing", 8313},
            {"Future's Market", 8321}, {"Minion Dematerializer", 8316}, {"Biscuit Delivery", 8345},
            {"Cosmic Insight", 8347}, {"Approach Velocity", 8410}, {"Time Warp Tonic", 8352},
            {"Adaptive Force", 5008}, {"Attack Speed", 5005}, {"Ability Haste", 5007},
            {"Armor", 5002}, {"Magic Resist", 5003}, {"Health", 5001}
        };
        public static readonly Dictionary<string, int> spellDict = new Dictionary<string, int>()
        {
            {"Cleanse", 1}, {"Exhaust", 3}, {"Flash", 4}, {"Ghost", 6}, {"Heal", 7},
            {"Smite", 11}, {"Teleport", 12}, {"Ignite", 14}, {"Barrier", 21}
        };
    }
}
