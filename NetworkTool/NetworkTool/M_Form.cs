using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Diagnostics;
using Microsoft.Win32;

namespace NetworkTool{
public partial class M_Form : Form{
public M_Form(){
InitializeComponent();
}

private void M_Form_Load(object sender, EventArgs e){
List<string> DBGN=new List<string>();
DBGN.Add("Enabled:");
foreach(string inst in GetEnabledInstances()){
DBGN.Add(inst);
}
DBGN.Add(" ");
DBGN.Add("Disabled:");
foreach(string inst in GetDisabledInstances()){
DBGN.Add(inst);
}

DBG_.Lines = DBGN.ToArray();
}


string[] GetNetInfoFromMachine(string RetTipe){ string[] rettie = { "No Valid Return Type" };
List<string> Names = new List<string>();
List<string> Descriptions = new List<string>();
List<string> IDS = new List<string>();
List<string> Addresses = new List<string>();
foreach (NetworkInterface NetTyin in NetworkInterface.GetAllNetworkInterfaces()){
Names.Add(NetTyin.Name);
Descriptions.Add(NetTyin.Description);
IDS.Add(NetTyin.Id);
Addresses.Add(NetTyin.GetPhysicalAddress().ToString());
}




List<string> RegisNames = new List<string>();
List<string> PnPInstanceId = new List<string>();
List<string> MediaSubType=new List<string>();
List<string> MST_Parent=new List<string>();

//We Will Use Method 1 As It Saves Performance And Time, Everyone Else Uses Method 2 short XD


//method 1
//RegistryKey OurNetInfo=Registry.LocalMachine.OpenSubKey("SYSTEM").OpenSubKey("CurrentControlSet").OpenSubKey("Control").OpenSubKey("Network");
//method 1 short
RegistryKey OurNetInfo=Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Network",true);
//method 2
//RegistryKey OurNetInfo=RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,RegistryView.Registry32).OpenSubKey("SYSTEM").OpenSubKey("CurrentControlSet").OpenSubKey("Control").OpenSubKey("Network");
//method 2 short
//RegistryKey OurNetInfo=RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,RegistryView.Registry32).OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Network",true);

List<string> NotRegistryKeyHives=new List<string>() { "null",""," ","Connections", "Interfaces" , "LightweightCallHandlers", "NetworkLocationWizard", "SharedAccessConnection" };

RegistryKey NetRegLoc=RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,RegistryView.Registry32);

foreach(string Kei in OurNetInfo.GetSubKeyNames()){
string[] OPos= Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Network\" + Kei, true).GetSubKeyNames();
if (!NotRegistryKeyHives.Contains(Kei)&&OPos.Contains("Descriptions")){
NetRegLoc=Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Network\"+Kei, true);
}
}

List<RegistryKey> NetKeyList=new List<RegistryKey>();
List<string> Gret=new List<string>();
foreach(string Possi in NetRegLoc.GetSubKeyNames()){
if(Possi!="Descriptions"){
RegistryKey TempNetKei= NetRegLoc.OpenSubKey(Possi+"\\Connection", true);
string TempNetName= (string)TempNetKei.GetValue("Name", true);
if(TempNetKei.GetValueNames().Contains("PnPInstanceId")){

if(TempNetKei.GetValueNames().Contains("MediaSubType")){
int val= (int)TempNetKei.GetValue("MediaSubType");
MediaSubType.Add(val.ToString());
}else{
MediaSubType.Add("None");
}

if(Names.Contains(TempNetName)){
Gret.Add("ENABLED");
}else{
Gret.Add("DISABLED");
}

NetKeyList.Add(TempNetKei);
RegisNames.Add(TempNetName);
PnPInstanceId.Add((string)TempNetKei.GetValue("PnPInstanceId", true));


}
}
}







string rexi = RetTipe.ToLower();
if (rexi == "names"){
rettie = Names.ToArray();
}else if (rexi == "descriptions"){
rettie = Descriptions.ToArray();
}else if (rexi == "ids"){
rettie = IDS.ToArray();
}else if (rexi == "addresses"){
rettie = Addresses.ToArray();
}else if (rexi == "registrynames"){
rettie = RegisNames.ToArray();
}else if (rexi == "pnpinstanceid"){
rettie = PnPInstanceId.ToArray();
}else if (rexi == "mediasubtype"){
rettie = MediaSubType.ToArray();
}else if (rexi == "state"){
rettie = Gret.ToArray();
}


return rettie;
}



static void EnableNetworkInterface(string interfaceName){
ProcessStartInfo psi =new ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" enable");Process p = new Process();
psi.CreateNoWindow = true;
psi.WindowStyle=ProcessWindowStyle.Hidden;
p.StartInfo = psi;
p.Start();
}

static void DisableNetworkInterface(string interfaceName){
ProcessStartInfo psi =new ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" disable");Process p = new Process();
psi.CreateNoWindow = true;
psi.WindowStyle=ProcessWindowStyle.Hidden;
p.StartInfo = psi;
p.Start();
}


string[] GetEnabledInstances(){
string[] States = GetNetInfoFromMachine("State");
string[] PnpInstanceIds = GetNetInfoFromMachine("pnpinstanceid");
string[] RegisNames = GetNetInfoFromMachine("registrynames");
List<string> Greturn = new List<string>();
for (var i = 0; i < RegisNames.Length; i++){
if (States[i].ToLower() == "enabled" && PnpInstanceIds[i].Trim(' ').StartsWith("PCI\\")){
Greturn.Add(RegisNames[i]);
}
}
return Greturn.ToArray();
}

string[] GetDisabledInstances(){
string[] States = GetNetInfoFromMachine("State");
string[] PnpInstanceIds = GetNetInfoFromMachine("pnpinstanceid");
string[] RegisNames = GetNetInfoFromMachine("registrynames");
List<string> Greturn = new List<string>();
for (var i = 0; i < RegisNames.Length; i++){
if (States[i].ToLower() == "disabled" && PnpInstanceIds[i].Trim(' ').StartsWith("PCI\\")){
Greturn.Add(RegisNames[i]);
}
}
return Greturn.ToArray();
}


private void DisableAllNetworks_Click(object sender, EventArgs e){
foreach (string nam in GetEnabledInstances()){
DisableNetworkInterface(nam);
}
}

private void EnableAllNetworks_Click(object sender, EventArgs e){
foreach (string nam in GetDisabledInstances()){
EnableNetworkInterface(nam);
}
}





private void GetAllDataOut_Click(object sender, EventArgs e){
string[] Names = GetNetInfoFromMachine("Names");
string[] Ids = GetNetInfoFromMachine("Ids");
string[] Descriptions = GetNetInfoFromMachine("Descriptions");
string[] addresses = GetNetInfoFromMachine("Addresses");
string[] States =   GetNetInfoFromMachine("State");         
string[] PnpInstanceIds = GetNetInfoFromMachine("pnpinstanceid");
string[] MediaSubType = GetNetInfoFromMachine("mediasubtype");
string[] RegisNames = GetNetInfoFromMachine("registrynames");
List<string> Greturn = new List<string>();
for (var i=0;i< RegisNames.Length;i++){
Greturn.Add("Found Network: "+i.ToString());
Greturn.Add("Registry Name: " + RegisNames[i]);
Greturn.Add("Pnp Instance Id: "+PnpInstanceIds[i]);
Greturn.Add("Media Sub Type: " + MediaSubType[i]);
Greturn.Add("State: "+States[i]);
Greturn.Add(" ");
if(States[i].ToLower()=="enabled"){
for(var ix=0;ix< Names.Length;ix++){
if(Names[ix]==RegisNames[i] ){
Greturn.Add("Name: "+Names[ix]);
Greturn.Add("Description: " + Descriptions[ix]);
Greturn.Add("Id: " + Ids[ix]);
Greturn.Add("Address: " + addresses[ix]);
}}

}

Greturn.Add(" ");
Greturn.Add(" ");
Greturn.Add(" ");
}


Greturn.RemoveAt(Greturn.Count-1);
DBG_.Lines = Greturn.ToArray();
}

RegistryKey MacAddressKeyStore() { return Registry.LocalMachine.OpenSubKey(@"SYSTEM\ControlSet001\Control\Class", true); }

string NetworkKeystoreId(){
RegistryKey RegistryItemList=Registry.LocalMachine.OpenSubKey(@"SYSTEM\ControlSet001\Control\Class", true);
string keiloc = "";
foreach(string key in RegistryItemList.GetSubKeyNames()){
RegistryKey subkei = MacAddressKeyStore().OpenSubKey(key, true);
if (subkei.GetValueNames().Contains("Class")){
if((string) subkei.GetValue("Class")=="Net"){
keiloc=key;break;
}
}}
return keiloc;
}

private void SpoofWifiAndEnthernet_Click(object sender, EventArgs e){
string keiloc= NetworkKeystoreId();

List<string> MacAddresses=new List<string>();
MacAddresses.Add(" ");
MacAddresses.Add("!NHA MAC ADDRESS FINDING ALGO V1.5!");
MacAddresses.Add(" ");
MacAddresses.Add(@"Network Keys Stored In: SYSTEM\ControlSet001\Control\Class\"+keiloc);
MacAddresses.Add(" ");
MacAddresses.Add(" ");

RegistryKey NetKeys=Registry.LocalMachine.OpenSubKey(@"SYSTEM\ControlSet001\Control\Class\"+ keiloc, true);
foreach(string keystore in NetKeys.GetSubKeyNames()){
if(keystore!="Properties"){
RegistryKey SubKei=Registry.LocalMachine.OpenSubKey(@"SYSTEM\ControlSet001\Control\Class\"+ keiloc+"\\"+keystore,true);
if(SubKei.GetValueNames().Contains("ComponentId")){
if(((string)SubKei.GetValue("ComponentId")).Trim(' ').StartsWith("PCI\\")&&SubKei.GetValueNames().Contains("NetCfgInstanceId")){
string MAC= ((string)SubKei.GetValue("NetCfgInstanceId")).Replace("{", "").Replace("}", "");
string DEVICE= (string)SubKei.GetValue("DriverDesc");
MacAddresses.Add("Network Key: "+keystore);
MacAddresses.Add("Device Name: "+DEVICE);

bool MacChanged=false;
if(SubKei.GetValueNames().Contains("BKG_NetCfgInstanceId")){
string MACBKG= ((string)SubKei.GetValue("BKG_NetCfgInstanceId")).Replace("{", "").Replace("}", "");
if(MACBKG!=MAC){
 MacChanged=true;
MacAddresses.Add("Original MAC Address: "+ MACBKG);
}else{
}
}
           
if(MacChanged==false){
MacAddresses.Add("MAC Address: "+MAC);
}else{
MacAddresses.Add("(SPOOFED) MAC Address: "+MAC);
}
                            

MacAddresses.Add(" ");
}
}}
}
DBG_.Lines=MacAddresses.ToArray();

}

private void SpoofAll_Click(object sender, EventArgs e){
string keiloc= NetworkKeystoreId();

List<string> MacAddresses=new List<string>();
MacAddresses.Add(" ");
MacAddresses.Add("!NHA MAC ADDRESS FINDING ALGO V1.5!");
MacAddresses.Add(" ");
MacAddresses.Add(@"Network Keys Stored In: SYSTEM\ControlSet001\Control\Class\"+keiloc);
MacAddresses.Add(" ");
MacAddresses.Add(" ");

RegistryKey NetKeys=Registry.LocalMachine.OpenSubKey(@"SYSTEM\ControlSet001\Control\Class\"+ keiloc, true);
foreach(string keystore in NetKeys.GetSubKeyNames()){
if(keystore!="Properties"){
RegistryKey SubKei=Registry.LocalMachine.OpenSubKey(@"SYSTEM\ControlSet001\Control\Class\"+ keiloc+"\\"+keystore,true);
if(SubKei.GetValueNames().Contains("ComponentId")){
if(((string)SubKei.GetValue("ComponentId")).Trim(' ').StartsWith("PCI\\")&&SubKei.GetValueNames().Contains("NetCfgInstanceId")){
string MAC= ((string)SubKei.GetValue("NetCfgInstanceId")).Replace("{", "").Replace("}", "");
string NEWMAC= CreateNewMACAddress();
string DEVICE= (string)SubKei.GetValue("DriverDesc");
if(!SubKei.GetValueNames().Contains("BKG_NetCfgInstanceId")){
SubKei.SetValue("BKG_NetCfgInstanceId","{"+MAC+"}");
}

MacAddresses.Add("Network Key: "+keystore);
MacAddresses.Add("Device Name: "+DEVICE);
MacAddresses.Add("*OLD MAC Address: "+MAC);
MacAddresses.Add("NEW! MAC Address: "+NEWMAC.Replace("{","").Replace("}",""));
MacAddresses.Add(" ");
if(SubKei.GetValueNames().Contains("BKG_NetCfgInstanceId")){SubKei.SetValue("NetCfgInstanceId",NEWMAC);}

}
}}
}
DBG_.Lines=MacAddresses.ToArray();

}



private void RESETMAC_Click(object sender, EventArgs e){
string keiloc= NetworkKeystoreId();

List<string> MacAddresses=new List<string>();
MacAddresses.Add(" ");
MacAddresses.Add("!NHA MAC ADDRESS FINDING ALGO V1.5!");
MacAddresses.Add(" ");
MacAddresses.Add(@"Network Keys Stored In: SYSTEM\ControlSet001\Control\Class\"+keiloc);
MacAddresses.Add(" ");
MacAddresses.Add(" ");

RegistryKey NetKeys=Registry.LocalMachine.OpenSubKey(@"SYSTEM\ControlSet001\Control\Class\"+ keiloc, true);
foreach(string keystore in NetKeys.GetSubKeyNames()){
if(keystore!="Properties"){
RegistryKey SubKei=Registry.LocalMachine.OpenSubKey(@"SYSTEM\ControlSet001\Control\Class\"+ keiloc+"\\"+keystore,true);
if(SubKei.GetValueNames().Contains("ComponentId")){
if(((string)SubKei.GetValue("ComponentId")).Trim(' ').StartsWith("PCI\\")&&SubKei.GetValueNames().Contains("NetCfgInstanceId")){
string MAC= ((string)SubKei.GetValue("NetCfgInstanceId")).Replace("{", "").Replace("}", "");
if(SubKei.GetValueNames().Contains("BKG_NetCfgInstanceId")){
string NEWMAC=(string)SubKei.GetValue("BKG_NetCfgInstanceId");
string DEVICE= (string)SubKei.GetValue("DriverDesc");
SubKei.SetValue("NetCfgInstanceId",NEWMAC);

MacAddresses.Add("Network Key: "+keystore);
MacAddresses.Add("Device Name: "+DEVICE);
MacAddresses.Add("*OLD MAC Address: "+MAC);
MacAddresses.Add("NEW! MAC Address: "+NEWMAC.Replace("{","").Replace("}",""));
MacAddresses.Add(" ");

}

}
}}
}

DBG_.Lines=MacAddresses.ToArray();
}

        string chars = "ABCDEF0123456789";
Random random = new Random();
string RandomChar(){
 return chars[random.Next(chars.Length)].ToString();
}

string CreateNewMACAddress(){

string startax=RandomChar()+RandomChar()+RandomChar()+RandomChar()+RandomChar()+RandomChar()+RandomChar()+ RandomChar();

string startbx=RandomChar()+RandomChar()+RandomChar()+RandomChar();
            
string startcx=RandomChar()+RandomChar()+RandomChar()+RandomChar();
            
string startdx=RandomChar()+RandomChar()+RandomChar()+RandomChar();

string startex=RandomChar()+RandomChar()+RandomChar()+RandomChar()+RandomChar()+RandomChar()+RandomChar()+RandomChar()+RandomChar()+RandomChar()+RandomChar()+RandomChar();

return "{"+startax+"-"+startbx+"-"+startcx+"-"+startdx+"-"+startex+"}";
}




}
}
