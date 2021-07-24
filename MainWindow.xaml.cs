using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Win32;
using System.Diagnostics;

namespace Cogent_RPG_Character_Sheet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void onSaveClick(object sender, RoutedEventArgs e)
        {
            CharacterData characterData = gatherCharacterData();
            string jsonString = JsonConvert.SerializeObject(characterData);
            JObject jsonObject = JObject.Parse(jsonString);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                Writejson(saveFileDialog.FileName, jsonObject);
            }
        }

        private void onOpenClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true) 
            {
                JObject jsonObject = Readjson(openFileDialog.FileName);
                string jsonString = JsonConvert.SerializeObject(jsonObject);
                CharacterData characterData = JsonConvert.DeserializeObject<CharacterData>(jsonString);
                populateCharacterData(characterData);
            }
        }

        public JObject Readjson(string jsonfile)
        {
            using (System.IO.StreamReader file = System.IO.File.OpenText(jsonfile))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject jObject = (JObject)JToken.ReadFrom(reader);
                    return jObject;
                }
            }
        }

        public void Writejson(string jsonfile, JObject jObject)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(jsonfile))
            {
                file.Write(jObject.ToString());
            }
        }

        private void populateCharacterData(CharacterData characterData)
        {
            CharacterName.Text = characterData.CharacterName;
            PlayerName.Text = characterData.PlayerName;
            Age.Text = characterData.Age;
            Race.Text = characterData.Race;
            Height.Text = characterData.Height;
            BodyType.Text = characterData.BodyType;
            Disposition.Text = characterData.Disposition;
            DisablingCharacteristics.Text = characterData.DisablingCharacteristics;
            History.Text = characterData.History;
            BeliefsMorality.Text = characterData.BeliefsMorality;
            GoalsAspirations.Text = characterData.GoalsAspirations;
            STR0.IsChecked = characterData.STR0;
            STR1.IsChecked = characterData.STR1;
            STR2.IsChecked = characterData.STR2;
            STR3.IsChecked = characterData.STR3;
            STR4.IsChecked = characterData.STR4;
            REF0.IsChecked = characterData.REF0;
            REF1.IsChecked = characterData.REF1;
            REF2.IsChecked = characterData.REF2;
            REF3.IsChecked = characterData.REF3;
            REF4.IsChecked = characterData.REF4;
            INT0.IsChecked = characterData.INT0;
            INT1.IsChecked = characterData.INT1;
            INT2.IsChecked = characterData.INT2;
            INT3.IsChecked = characterData.INT3;
            INT4.IsChecked = characterData.INT4;
            Perception0.IsChecked = characterData.Perception0;
            Perception1.IsChecked = characterData.Perception1;
            Perception2.IsChecked = characterData.Perception2;
            Perception3.IsChecked = characterData.Perception3;
            Perception4.IsChecked = characterData.Perception4;
            Athletics0.IsChecked = characterData.Athletics0;
            Athletics1.IsChecked = characterData.Athletics1;
            Athletics2.IsChecked = characterData.Athletics2;
            Athletics3.IsChecked = characterData.Athletics3;
            Athletics4.IsChecked = characterData.Athletics4;
            Grapple0.IsChecked = characterData.Grapple0;
            Grapple1.IsChecked = characterData.Grapple1;
            Grapple2.IsChecked = characterData.Grapple2;
            Grapple3.IsChecked = characterData.Grapple3;
            Grapple4.IsChecked = characterData.Grapple4;
            Swim0.IsChecked = characterData.Swim0;
            Swim1.IsChecked = characterData.Swim1;
            Swim2.IsChecked = characterData.Swim2;
            Swim3.IsChecked = characterData.Swim3;
            Swim4.IsChecked = characterData.Swim4;
            AimThrow0.IsChecked = characterData.AimThrow0;
            AimThrow1.IsChecked = characterData.AimThrow1;
            AimThrow2.IsChecked = characterData.AimThrow2;
            AimThrow3.IsChecked = characterData.AimThrow3;
            AimThrow4.IsChecked = characterData.AimThrow4;
            Acrobatics0.IsChecked = characterData.Acrobatics0;
            Acrobatics1.IsChecked = characterData.Acrobatics1;
            Acrobatics2.IsChecked = characterData.Acrobatics2;
            Acrobatics3.IsChecked = characterData.Acrobatics3;
            Acrobatics4.IsChecked = characterData.Acrobatics4;
            RidePilot0.IsChecked = characterData.RidePilot0;
            RidePilot1.IsChecked = characterData.RidePilot1;
            RidePilot2.IsChecked = characterData.RidePilot2;
            RidePilot3.IsChecked = characterData.RidePilot3;
            RidePilot4.IsChecked = characterData.RidePilot4;
            SleightOfHand0.IsChecked = characterData.SleightOfHand0;
            SleightOfHand1.IsChecked = characterData.SleightOfHand1;
            SleightOfHand2.IsChecked = characterData.SleightOfHand2;
            SleightOfHand3.IsChecked = characterData.SleightOfHand3;
            SleightOfHand4.IsChecked = characterData.SleightOfHand4;
            Stealth0.IsChecked = characterData.Stealth0;
            Stealth1.IsChecked = characterData.Stealth1;
            Stealth2.IsChecked = characterData.Stealth2;
            Stealth3.IsChecked = characterData.Stealth3;
            Stealth4.IsChecked = characterData.Stealth4;
            Deception0.IsChecked = characterData.Deception0;
            Deception1.IsChecked = characterData.Deception1;
            Deception2.IsChecked = characterData.Deception2;
            Deception3.IsChecked = characterData.Deception3;
            Deception4.IsChecked = characterData.Deception4;
            Persuasion0.IsChecked = characterData.Persuasion0;
            Persuasion1.IsChecked = characterData.Persuasion1;
            Persuasion2.IsChecked = characterData.Persuasion2;
            Persuasion3.IsChecked = characterData.Persuasion3;
            Persuasion4.IsChecked = characterData.Persuasion4;
            Infiltration0.IsChecked = characterData.Infiltration0;
            Infiltration1.IsChecked = characterData.Infiltration1;
            Infiltration2.IsChecked = characterData.Infiltration2;
            Infiltration3.IsChecked = characterData.Infiltration3;
            Infiltration4.IsChecked = characterData.Infiltration4;
            Survival0.IsChecked = characterData.Survival0;
            Survival1.IsChecked = characterData.Survival1;
            Survival2.IsChecked = characterData.Survival2;
            Survival3.IsChecked = characterData.Survival3;
            Survival4.IsChecked = characterData.Survival4;
            Vocation1_1.IsChecked = characterData.Vocation1_1;
            Vocation1_2.IsChecked = characterData.Vocation1_2;
            Vocation1_3.IsChecked = characterData.Vocation1_3;
            Vocation1_4.IsChecked = characterData.Vocation1_4;
            Vocation2_1.IsChecked = characterData.Vocation2_1;
            Vocation2_2.IsChecked = characterData.Vocation2_2;
            Vocation2_3.IsChecked = characterData.Vocation2_3;
            Vocation2_4.IsChecked = characterData.Vocation2_4;
            Vocation3_1.IsChecked = characterData.Vocation3_1;
            Vocation3_2.IsChecked = characterData.Vocation3_2;
            Vocation3_3.IsChecked = characterData.Vocation3_3;
            Vocation3_4.IsChecked = characterData.Vocation3_4;
            VocationLabel1.Text = characterData.VocationLabel1;
            VocationLabel2.Text = characterData.VocationLabel2;
            VocationLabel3.Text = characterData.VocationLabel3;
            Proficiency1_1.IsChecked = characterData.Proficiency1_1;
            Proficiency1_2.IsChecked = characterData.Proficiency1_2;
            Proficiency2_1.IsChecked = characterData.Proficiency2_1;
            Proficiency2_2.IsChecked = characterData.Proficiency2_2;
            Proficiency3_1.IsChecked = characterData.Proficiency3_1;
            Proficiency3_2.IsChecked = characterData.Proficiency3_2;
            ProficiencyLabel1.Text = characterData.ProficiencyLabel1;
            ProficiencyLabel2.Text = characterData.ProficiencyLabel2;
            ProficiencyLabel3.Text = characterData.ProficiencyLabel3;
            Equipment.Text = characterData.Equipment;
            Inventory.Text = characterData.Inventory;
            Notes.Text = characterData.Notes;
            DestinyPoints1.IsChecked = characterData.DestinyPoints1;
            DestinyPoints2.IsChecked = characterData.DestinyPoints2;
            DestinyPoints3.IsChecked = characterData.DestinyPoints3;
            DestinyPoints4.IsChecked = characterData.DestinyPoints4;
            DestinyPoints5.IsChecked = characterData.DestinyPoints5;
            DestinyPoints6.IsChecked = characterData.DestinyPoints6;
            DestinyPoints7.IsChecked = characterData.DestinyPoints7;
            DestinyPoints8.IsChecked = characterData.DestinyPoints8;
            CommercePoints1.IsChecked = characterData.CommercePoints1;
            CommercePoints2.IsChecked = characterData.CommercePoints2;
            CommercePoints3.IsChecked = characterData.CommercePoints3;
            CommercePoints4.IsChecked = characterData.CommercePoints4;
            CommercePoints5.IsChecked = characterData.CommercePoints5;
            CommercePoints6.IsChecked = characterData.CommercePoints6;
            CommercePoints7.IsChecked = characterData.CommercePoints7;
            CommercePoints8.IsChecked = characterData.CommercePoints8;
            Injury1.Text = characterData.Injury1;
            Injury2.Text = characterData.Injury2;
            Injury3.Text = characterData.Injury3;
            Injury4.Text = characterData.Injury4;
            Penalty1.Text = characterData.Penalty1;
            Penalty2.Text = characterData.Penalty2;
            Penalty3.Text = characterData.Penalty3;
            Penalty4.Text = characterData.Penalty4;
        }

        private CharacterData gatherCharacterData()
        {
            CharacterData characterData = new CharacterData();
            characterData.CharacterName = CharacterName.Text;
            characterData.PlayerName = PlayerName.Text;
            characterData.Age = Age.Text;
            characterData.Race = Race.Text;
            characterData.Height = Height.Text;
            characterData.BodyType = BodyType.Text;
            characterData.Disposition = Disposition.Text;
            characterData.DisablingCharacteristics = DisablingCharacteristics.Text;
            characterData.History = History.Text;
            characterData.BeliefsMorality = BeliefsMorality.Text;
            characterData.GoalsAspirations = GoalsAspirations.Text;
            characterData.STR0 = (bool)STR0.IsChecked;
            characterData.STR1 = (bool)STR1.IsChecked;
            characterData.STR2 = (bool)STR2.IsChecked;
            characterData.STR3 = (bool)STR3.IsChecked;
            characterData.STR4 = (bool)STR4.IsChecked;
            characterData.REF0 = (bool)REF0.IsChecked;
            characterData.REF1 = (bool)REF1.IsChecked;
            characterData.REF2 = (bool)REF2.IsChecked;
            characterData.REF3 = (bool)REF3.IsChecked;
            characterData.REF4 = (bool)REF4.IsChecked;
            characterData.INT0 = (bool)INT0.IsChecked;
            characterData.INT1 = (bool)INT1.IsChecked;
            characterData.INT2 = (bool)INT2.IsChecked;
            characterData.INT3 = (bool)INT3.IsChecked;
            characterData.INT4 = (bool)INT4.IsChecked;
            characterData.Perception0 = (bool)Perception0.IsChecked;
            characterData.Perception1 = (bool)Perception1.IsChecked;
            characterData.Perception2 = (bool)Perception2.IsChecked;
            characterData.Perception3 = (bool)Perception3.IsChecked;
            characterData.Perception4 = (bool)Perception4.IsChecked;
            characterData.Athletics0 = (bool)Athletics0.IsChecked;
            characterData.Athletics1 = (bool)Athletics1.IsChecked;
            characterData.Athletics2 = (bool)Athletics2.IsChecked;
            characterData.Athletics3 = (bool)Athletics3.IsChecked;
            characterData.Athletics4 = (bool)Athletics4.IsChecked;
            characterData.Grapple0 = (bool)Grapple0.IsChecked;
            characterData.Grapple1 = (bool)Grapple1.IsChecked;
            characterData.Grapple2 = (bool)Grapple2.IsChecked;
            characterData.Grapple3 = (bool)Grapple3.IsChecked;
            characterData.Grapple4 = (bool)Grapple4.IsChecked;
            characterData.Swim0 = (bool)Swim0.IsChecked;
            characterData.Swim1 = (bool)Swim1.IsChecked;
            characterData.Swim2 = (bool)Swim2.IsChecked;
            characterData.Swim3 = (bool)Swim3.IsChecked;
            characterData.Swim4 = (bool)Swim4.IsChecked;
            characterData.AimThrow0 = (bool)AimThrow0.IsChecked;
            characterData.AimThrow1 = (bool)AimThrow1.IsChecked;
            characterData.AimThrow2 = (bool)AimThrow2.IsChecked;
            characterData.AimThrow3 = (bool)AimThrow3.IsChecked;
            characterData.AimThrow4 = (bool)AimThrow4.IsChecked;
            characterData.Acrobatics0 = (bool)Acrobatics0.IsChecked;
            characterData.Acrobatics1 = (bool)Acrobatics1.IsChecked;
            characterData.Acrobatics2 = (bool)Acrobatics2.IsChecked;
            characterData.Acrobatics3 = (bool)Acrobatics3.IsChecked;
            characterData.Acrobatics4 = (bool)Acrobatics4.IsChecked;
            characterData.RidePilot0 = (bool)RidePilot0.IsChecked;
            characterData.RidePilot1 = (bool)RidePilot1.IsChecked;
            characterData.RidePilot2 = (bool)RidePilot2.IsChecked;
            characterData.RidePilot3 = (bool)RidePilot3.IsChecked;
            characterData.RidePilot4 = (bool)RidePilot4.IsChecked;
            characterData.SleightOfHand0 = (bool)SleightOfHand0.IsChecked;
            characterData.SleightOfHand1 = (bool)SleightOfHand1.IsChecked;
            characterData.SleightOfHand2 = (bool)SleightOfHand2.IsChecked;
            characterData.SleightOfHand3 = (bool)SleightOfHand3.IsChecked;
            characterData.SleightOfHand4 = (bool)SleightOfHand4.IsChecked;
            characterData.Stealth0 = (bool)Stealth0.IsChecked;
            characterData.Stealth1 = (bool)Stealth1.IsChecked;
            characterData.Stealth2 = (bool)Stealth2.IsChecked;
            characterData.Stealth3 = (bool)Stealth3.IsChecked;
            characterData.Stealth4 = (bool)Stealth4.IsChecked;
            characterData.Deception0 = (bool)Deception0.IsChecked;
            characterData.Deception1 = (bool)Deception1.IsChecked;
            characterData.Deception2 = (bool)Deception2.IsChecked;
            characterData.Deception3 = (bool)Deception3.IsChecked;
            characterData.Deception4 = (bool)Deception4.IsChecked;
            characterData.Persuasion0 = (bool)Persuasion0.IsChecked;
            characterData.Persuasion1 = (bool)Persuasion1.IsChecked;
            characterData.Persuasion2 = (bool)Persuasion2.IsChecked;
            characterData.Persuasion3 = (bool)Persuasion3.IsChecked;
            characterData.Persuasion4 = (bool)Persuasion4.IsChecked;
            characterData.Infiltration0 = (bool)Infiltration0.IsChecked;
            characterData.Infiltration1 = (bool)Infiltration1.IsChecked;
            characterData.Infiltration2 = (bool)Infiltration2.IsChecked;
            characterData.Infiltration3 = (bool)Infiltration3.IsChecked;
            characterData.Infiltration4 = (bool)Infiltration4.IsChecked;
            characterData.Survival0 = (bool)Survival0.IsChecked;
            characterData.Survival1 = (bool)Survival1.IsChecked;
            characterData.Survival2 = (bool)Survival2.IsChecked;
            characterData.Survival3 = (bool)Survival3.IsChecked;
            characterData.Survival4 = (bool)Survival4.IsChecked;
            characterData.Vocation1_1 = (bool)Vocation1_1.IsChecked;
            characterData.Vocation1_2 = (bool)Vocation1_2.IsChecked;
            characterData.Vocation1_3 = (bool)Vocation1_3.IsChecked;
            characterData.Vocation1_4 = (bool)Vocation1_4.IsChecked;
            characterData.Vocation2_1 = (bool)Vocation2_1.IsChecked;
            characterData.Vocation2_2 = (bool)Vocation2_2.IsChecked;
            characterData.Vocation2_3 = (bool)Vocation2_3.IsChecked;
            characterData.Vocation2_4 = (bool)Vocation2_4.IsChecked;
            characterData.Vocation3_1 = (bool)Vocation3_1.IsChecked;
            characterData.Vocation3_2 = (bool)Vocation3_2.IsChecked;
            characterData.Vocation3_3 = (bool)Vocation3_3.IsChecked;
            characterData.Vocation3_4 = (bool)Vocation3_4.IsChecked;
            characterData.VocationLabel1 = VocationLabel1.Text;
            characterData.VocationLabel2 = VocationLabel2.Text;
            characterData.VocationLabel3 = VocationLabel3.Text;
            characterData.Proficiency1_1 = (bool)Proficiency1_1.IsChecked;
            characterData.Proficiency1_2 = (bool)Proficiency1_2.IsChecked;
            characterData.Proficiency2_1 = (bool)Proficiency2_1.IsChecked;
            characterData.Proficiency2_2 = (bool)Proficiency2_2.IsChecked;
            characterData.Proficiency3_1 = (bool)Proficiency3_1.IsChecked;
            characterData.Proficiency3_2 = (bool)Proficiency3_2.IsChecked;
            characterData.ProficiencyLabel1 = ProficiencyLabel1.Text;
            characterData.ProficiencyLabel2 = ProficiencyLabel2.Text;
            characterData.ProficiencyLabel3 = ProficiencyLabel3.Text;
            characterData.Equipment = Equipment.Text;
            characterData.Inventory = Inventory.Text;
            characterData.Notes = Notes.Text;
            characterData.DestinyPoints1 = (bool)DestinyPoints1.IsChecked;
            characterData.DestinyPoints2 = (bool)DestinyPoints2.IsChecked;
            characterData.DestinyPoints3 = (bool)DestinyPoints3.IsChecked;
            characterData.DestinyPoints4 = (bool)DestinyPoints4.IsChecked;
            characterData.DestinyPoints5 = (bool)DestinyPoints5.IsChecked;
            characterData.DestinyPoints6 = (bool)DestinyPoints6.IsChecked;
            characterData.DestinyPoints7 = (bool)DestinyPoints7.IsChecked;
            characterData.DestinyPoints8 = (bool)DestinyPoints8.IsChecked;
            characterData.CommercePoints1 = (bool)CommercePoints1.IsChecked;
            characterData.CommercePoints2 = (bool)CommercePoints2.IsChecked;
            characterData.CommercePoints3 = (bool)CommercePoints3.IsChecked;
            characterData.CommercePoints4 = (bool)CommercePoints4.IsChecked;
            characterData.CommercePoints5 = (bool)CommercePoints5.IsChecked;
            characterData.CommercePoints6 = (bool)CommercePoints6.IsChecked;
            characterData.CommercePoints7 = (bool)CommercePoints7.IsChecked;
            characterData.CommercePoints8 = (bool)CommercePoints8.IsChecked;
            characterData.Injury1 = Injury1.Text;
            characterData.Injury2 = Injury2.Text;
            characterData.Injury3 = Injury3.Text;
            characterData.Injury4 = Injury4.Text;
            characterData.Penalty1 = Penalty1.Text;
            characterData.Penalty2 = Penalty2.Text;
            characterData.Penalty3 = Penalty3.Text;
            characterData.Penalty4 = Penalty4.Text;
            return characterData;
        }
    }
}