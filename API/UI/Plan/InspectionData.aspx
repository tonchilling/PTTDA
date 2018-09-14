<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="InspectionData.aspx.cs" Inherits="UI_Plan_InspectionData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../Js/boostrap.table.js" type="text/javascript"></script>
<script type="text/javascript">


    window.onload = function () {

        //  LoadTable();

        $('.region3').on('show.bs.collapse', function () {
            $('.collapse.in').collapse('show');
        });

    }

</script>

<style type="text/css">
 body
 {
 	   color:#000000;
		font-size:16px;
 	}
 	
 	.tbDetail  thead tr
 	{
 		 background-color:#007bff !important;
 		}
 		
 		.hiddenRow {
    padding: 0 !important;
}
td a
{
	color:#007bff;
	}
/*
   .table-fix table {
    width: 100%;
    display:block;
}
.table-fix thead {
    display: inline-block;
    width: 100%;
   
}

*/
 /* .table-fix tbody {
   
   display: block;
    width: 100%;
    overflow: auto;
}*/
  
  
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="container-fluid">
  <div class="row">
    <div class="col-sm-12">
<!--- Content --->

<div class="card cardbody">
 <div class="card-header"><i class="fa fa-cog fa-spin fa-2x" style="color:#428bca"></i> Inspection Data </div>
     <div class="card-body">


      <div class="row">
          <div class="col-sm-12">
          
    

          <div class="row" style="padding-top:10px;">

         
         
            <div class="col-sm-2">
           <div class="input-group">
  <span class="input-group-addon" id="Span1" >Year </span>
    <select name="Year" class="form-control" id="Year" data-val-required="The Year field is required." data-val="true" data-val-number="The field Year must be a number."><option value="2008">2008</option>
<option value="2009">2009</option>
<option value="2010">2010</option>
<option value="2011">2011</option>
<option value="2012">2012</option>
<option value="2013">2013</option>
<option value="2014">2014</option>
<option value="2015">2015</option>
<option value="2016">2016</option>
<option value="2017">2017</option>
<option selected="selected" value="2018">2018</option>
<option value="2019">2019</option>
<option value="2020">2020</option>
<option value="2021">2021</option>
<option value="2022">2022</option>
<option value="2023">2023</option>
<option value="2024">2024</option>
<option value="2025">2025</option>
<option value="2026">2026</option>
<option value="2027">2027</option>
</select>
</div>
          </div>

             <div class="col-sm-2">
           <div class="input-group">
  <span class="input-group-addon" id="Span5" >Month </span>
    <select name="FromMonth" class="form-control" id="FromMonth" data-val-required="The FromMonth field is required." data-val="true" data-val-number="The field FromMonth must be a number."><option selected="selected" value="0">ม.ค.</option>
<option value="1">ก.พ.</option>
<option value="2">มี.ค.</option>
<option value="3">เม.ย.</option>
<option value="4">พ.ค.</option>
<option value="5">มิ.ย.</option>
<option value="6">ก.ค.</option>
<option value="7">ส.ค.</option>
<option value="8">ก.ย.</option>
<option value="9">ต.ค.</option>
<option value="10">พ.ย.</option>
<option value="11">ธ.ค.</option>
</select>
</div>
          </div>
               <div class="col-sm-2">
           <div class="input-group">
  <span class="input-group-addon" id="Span3" >To </span>
   <select name="ToMonth" class="form-control" id="ToMonth" data-val-required="The ToMonth field is required." data-val="true" data-val-number="The field ToMonth must be a number."><option value="0">ม.ค.</option>
<option value="1">ก.พ.</option>
<option value="2">มี.ค.</option>
<option value="3">เม.ย.</option>
<option value="4">พ.ค.</option>
<option value="5">มิ.ย.</option>
<option value="6">ก.ค.</option>
<option value="7">ส.ค.</option>
<option value="8">ก.ย.</option>
<option value="9">ต.ค.</option>
<option value="10">พ.ย.</option>
<option selected="selected" value="11">ธ.ค.</option>
</select>
</div>
          </div>
           <div class="col-sm-3">
           <div class="input-group">
  <span class="input-group-addon" id="Span4" >Customer Type</span>
   <select name="CustomerTypeID" class="form-control" id="CustomerTypeID" data-val-required="The CustomerTypeID field is required." data-val="true" data-val-number="The field CustomerTypeID must be a number."><option selected="selected" value="0">ทั้งหมด</option>
<option value="37">PTT</option>
<option value="38">NGR</option>
<option value="39">NGV</option>
<option value="40">TREASURY DEPT.</option>
<option value="41">-</option>
</select>
</div>
          </div>
          
          </div>
            <div class="row" style="padding-top:10px;">

         
         
            <div class="col-sm-4">
           <div class="input-group">
  <span class="input-group-addon" id="Span2" >BV Station </span>
   <select name="StationID" class="form-control" id="StationID" data-val-required="The StationID field is required." data-val="true" data-val-number="The field StationID must be a number."><option selected="selected" value="0">ทั้งหมด</option>
<option value="196">10” Production Flow Line PH5 to PH3</option>
<option value="195">10” Production Flow Line PH5 to PH4</option>
<option value="676">12" 692R1 - Looping Hinkhong</option>
<option value="319">12" ATP(SPR)</option>
<option value="672">12" BV.22 - BKKCAO</option>
<option value="359">12" BV.22 - Chememan</option>
<option value="677">12" GKP 1</option>
<option value="671">16” สินภูฮ่อม (RC400)</option>
<option value="594">20" GSP4 (MP) - KEGCO (CC)</option>
<option value="540">24" RBMR - RPCL</option>
<option value="516">3" COTCO</option>
<option value="515">3" SSG</option>
<option value="537">3" U/G branch to NGV conventioanl station</option>
<option value="636">4" - Pipeline to CPF3</option>
<option value="316">4" NGV AA (NGV SV Progressive)</option>
<option value="308">4" NGV BCPSR (บางจาก เทพารักษ์)</option>
<option value="303">4" NGV BE (นาคสวัสดิ์ กม.28)</option>
<option value="304">4" NGV BF (บางปลา)</option>
<option value="315">4" NGV BHP1 (บ้านโพธิ์ (สุนันทา))</option>
<option value="291">4" NGV BWN (331 ขาออก)</option>
<option value="292">4" NGV KM83 (จันทร์เพ็ญ)</option>
<option value="296">4" NGV LCB</option>
<option value="314">4" NGV PT (ไผ่ทอง)</option>
<option value="307">4" NGV PTT TPR ( ปตท. เทพารักษ์)</option>
<option value="293">4" NGV SRC (ธิติปิโตเลียม)</option>
<option value="317">4" NGV SVW (วิมลรัตน์สุวินทวงศ์ขาออก)</option>
<option value="318">4" NGV SVW (สุวินทวงศ์ 83 ขาเข้า)</option>
<option value="674">4" NGV Tandeiw KM.116</option>
<option value="329">4" NGV VR</option>
<option value="306">4" NGV เทพารักษ์ Mother Station</option>
<option value="358">4" NGV ธนชัยชล</option>
<option value="290">4" NGV อำนวย</option>
<option value="294">4" NGV_CH (SPP Oil กัลยา)</option>
<option value="539">4" RBMR - KT</option>
<option value="552">4" RC4100_KP36.400 - NGV Ban Pong</option>
<option value="320">4" RC636 (KP.10.700) - NGV โรจนะ 2</option>
<option value="666">4" RC650 (KP.50.860) - NGV บึงคำพร้อย</option>
<option value="667">4" RC650 (KP.51.880) - NGV Susco</option>
<option value="663">4" RC650 (KP.xx.xxx) - NGV Mother Nimitmai 1-2</option>
<option value="673">4" RC670 TO KENZAI</option>
<option value="191">4" sales gas</option>
<option value="288">4" Siam Estern Group</option>
<option value="370">4" to HSC (ยกเลิกใช้ก๊าซแล้ว)</option>
<option value="361">4" to UMI1</option>
<option value="585">506R1 (BV12) - IND. Prapadaeng group</option>
<option value="500">6" IndusTrail ASIA</option>
<option value="595">6" MR PO7 - NGV Mother station</option>
<option value="311">6" NGV Banbeung Super</option>
<option value="300">6" NGV BB3 (แอนลิตา)</option>
<option value="305">6" NGV BST (บางเสาธง)</option>
<option value="299">6" NGV FM (ฟินมอร์)</option>
<option value="298">6" NGV SPD (เสปลนดิด)</option>
<option value="297">6" NGV Super K Power</option>
<option value="295">6" NGV Time Venture</option>
<option value="301">6" NGV TSN (ทัศนา)</option>
<option value="538">6" RBMR - NGV ราชบุรี</option>
<option value="627">6" RC4100 (KP.99.473) - NGV Latlumkaew</option>
<option value="532">6" RC5610_KP.5.300 - PTTGC Office</option>
<option value="590">6" RC616101 (KP.xxx.xxx) - NGV ศูนย์ราชการ</option>
<option value="669">6" RC650 (KP.48.873) - NGV World Gas</option>
<option value="407">6" RC690 (KP.53.300) - NGV BANNA-KHANGKOI</option>
<option value="408">6" RC69401 (KP.xxx) - NGV PMS SAKOL (KAENG KHOI)</option>
<option value="372">6" to DCC2</option>
<option value="367">6" to SFCC</option>
<option value="536">6" U/G branch to NGV mother station</option>
<option value="409">6" WK#5 - NGV KHANGKHOI MOTOR WK5</option>
<option value="504">6" ซอย9</option>
<option value="396">670 - TPL , TSC</option>
<option value="529">8" 5601R1 - MOC</option>
<option value="334">8" 661R1 - SGG</option>
<option value="487">8" BV#2 - Laemchabang</option>
<option value="302">8" NGV CSS (สันติสุข)</option>
<option value="628">8" RC4100 (KP.118.200) - NGV SCAN (สามโคก)</option>
<option value="629">8" RC4100 (KP.124.675) - NGV SAKOL</option>
<option value="321">8" RC636 (KP.18.667) - NGD โรจนะ</option>
<option value="664">8" RC650 (KP.48.050) - NGV Mother Nimitmai3</option>
<option value="704">8" RC650 (KP.48.050) - NGV Mother Station Lamlukk</option>
<option value="668">8" RC650 (KP.48.050) - NGV Mother Station Lamlukka</option>
<option value="312">ABP4.5</option>
<option value="49">ABPR1</option>
<option value="59">Alpha Power</option>
<option value="521">Aluminium (3")</option>
<option value="160">AmataBV</option>
<option value="287">Amatacity rayong group</option>
<option value="76">AN1</option>
<option value="77">AN10</option>
<option value="78">AN11</option>
<option value="79">AN12</option>
<option value="80">AN13</option>
<option value="81">AN2</option>
<option value="82">AN3</option>
<option value="83">AN4</option>
<option value="84">AN5</option>
<option value="85">AN6</option>
<option value="86">AN7</option>
<option value="87">AN8</option>
<option value="88">AN9</option>
<option value="151">AR1</option>
<option value="159">AR2</option>
<option value="274">Asia Pacific Glass</option>
<option value="58">AT1</option>
<option value="661">Bangchan Group</option>
<option value="52">BCS</option>
<option value="505">BRP</option>
<option value="1">BV1</option>
<option value="56">BV10</option>
<option value="15">BV11</option>
<option value="155">BV12</option>
<option value="139">BV13</option>
<option value="140">BV14</option>
<option value="141">BV15</option>
<option value="142">BV16</option>
<option value="138">BV17</option>
<option value="143">BV18</option>
<option value="144">BV19</option>
<option value="2">BV2</option>
<option value="106">BV2.1</option>
<option value="107">BV2.2</option>
<option value="53">BV2.3</option>
<option value="51">BV2.4</option>
<option value="54">BV2.5</option>
<option value="55">BV2.6</option>
<option value="166">BV20</option>
<option value="90">BV21</option>
<option value="31">BV22</option>
<option value="91">BV23</option>
<option value="92">BV24</option>
<option value="93">BV25</option>
<option value="167">BV26</option>
<option value="4">BV3</option>
<option value="171">BV3.1</option>
<option value="112">BV3.2</option>
<option value="113">BV3.3</option>
<option value="114">BV3.4</option>
<option value="62">BV3.5</option>
<option value="63">BV3.6</option>
<option value="64">BV3.7</option>
<option value="5">BV4</option>
<option value="108">BV4.1</option>
<option value="65">BV4.10</option>
<option value="66">BV4.11</option>
<option value="67">BV4.12</option>
<option value="68">BV4.13</option>
<option value="69">BV4.14</option>
<option value="70">BV4.15</option>
<option value="102">BV4.16</option>
<option value="103">BV4.17</option>
<option value="104">BV4.18</option>
<option value="169">BV4.19</option>
<option value="109">BV4.2</option>
<option value="110">BV4.3</option>
<option value="60">BV4.4</option>
<option value="61">BV4.5</option>
<option value="71">BV4.6</option>
<option value="72">BV4.7</option>
<option value="73">BV4.8</option>
<option value="74">BV4.9</option>
<option value="47">BV5</option>
<option value="20">BV6</option>
<option value="152">BV7</option>
<option value="8">BV8</option>
<option value="10">BV9</option>
<option value="132">BVW1</option>
<option value="153">BVW10</option>
<option value="154">BVW11</option>
<option value="36">BVW12</option>
<option value="133">BVW2</option>
<option value="134">BVW3</option>
<option value="135">BVW4</option>
<option value="136">BVW5</option>
<option value="137">BVW6</option>
<option value="178">BVW7</option>
<option value="156">BVW8</option>
<option value="157">BVW9</option>
<option value="693">BWCE</option>
<option value="176">CHANA MR</option>
<option value="131">CHANA PP</option>
<option value="216">Chemdal Asia Ltd.</option>
<option value="523">COFCO</option>
<option value="192">Condensate tank A</option>
<option value="193">Condensate tank B</option>
<option value="655">CPF2 1+180</option>
<option value="148">CRN1</option>
<option value="374">CROWN BEVCAN AND CLOSURES (THAILAND) CO., LTD.</option>
<option value="593">DPCU Plant</option>
<option value="567">Ekchai - RAMA2</option>
<option value="588">ENCO</option>
<option value="164">EPEC</option>
<option value="188">Fire water Building</option>
<option value="181">Fire water ESP</option>
<option value="186">Fire water GSP1</option>
<option value="187">Fire water GSP2</option>
<option value="183">Fire water GSP3</option>
<option value="184">Fire water GSP5</option>
<option value="185">Fire water GSP6</option>
<option value="182">Fire water Tank Farm</option>
<option value="180">Fire water, Gas RPLF</option>
<option value="194">Firewater tank</option>
<option value="682">Gate 4101R1 ( Tap RC4100 2+705 to Gate Kangwal)</option>
<option value="388">GATE 673 - KHOLER 2</option>
<option value="387">Gate 673 - RPC 2</option>
<option value="530">Gate4.1 - CHP2</option>
<option value="111">GDF</option>
<option value="405">GKP 1</option>
<option value="406">GKP2</option>
<option value="496">GLOW E (IND)</option>
<option value="161">GLOW IPP</option>
<option value="240">GM</option>
<option value="168">GNS</option>
<option value="190">GPP buried pipeline</option>
<option value="33">GSP</option>
<option value="105">GUT1</option>
<option value="170">GUT2</option>
<option value="514">HOT TAP PIONT TO NONGBON GATE</option>
<option value="32">IPT</option>
<option value="115">IRPC1</option>
<option value="116">IRPC2</option>
<option value="117">IRPC3</option>
<option value="118">IRPC4</option>
<option value="544">J Press</option>
<option value="546">JP United</option>
<option value="397">KERA TILE</option>
<option value="130">Khanom DPCU</option>
<option value="94">KKMR</option>
<option value="391">KOHLER 1</option>
<option value="626">KP 127+704 PTTNGD NAWANAKORN</option>
<option value="643">KSI (NEW)</option>
<option value="289">Laem Cha Bang Industrial</option>
<option value="491">LINDE</option>
<option value="502">Mabhka</option>
<option value="382">Meiji Cogen</option>
<option value="575">Millimade MLL (KP.4.727)</option>
<option value="508">MS</option>
<option value="129">NB1</option>
<option value="175">NBMR</option>
<option value="547">NDI</option>
<option value="625">Network บางชัน</option>
<option value="353">NG-Metering and Pipeline for Knauf Gymsum</option>
<option value="652">NGV - BKK (NGV BUS TERMINAL SVW)</option>
<option value="638">NGV - BN14 (NGV Bangna - Trad KM. 14)</option>
<option value="660">NGV - NS GAS (NGV NS GAS LPG)</option>
<option value="639">NGV - ON (NGV คุณดิษทัต)</option>
<option value="665">NGV - PNS (NGV PANNEE)</option>
<option value="637">NGV - RGD (NGV GOLDEN DRAGON)</option>
<option value="651">NGV - RK1 (NGV CITY CONNECT)</option>
<option value="653">NGV - RK2 (NGV CITY CONNECT 2)</option>
<option value="656">NGV - SVW2 (NGV KM.19) NGV SUWINTHAWONG 0+612</option>
<option value="657">NGV - SVW4 (NGV KM.39) NGV SUWINTHAWONG 1+889</option>
<option value="642">NGV 168</option>
<option value="662">NGV ASIA MEENBURI KP. 2+130</option>
<option value="648">NGV BCP KK (NGV BANGJAK)</option>
<option value="402">NGV Boonyarit</option>
<option value="632">NGV FPR MASTER STATION1,2</option>
<option value="568">NGV Kanjana Pisak</option>
<option value="670">NGV KAOWPRATHUMTIP</option>
<option value="634">NGV KITCHAI</option>
<option value="647">NGV Landsite (NGV SVB2)</option>
<option value="565">NGV Lers Kanlapluek</option>
<option value="384">NGV Nakhonsawan</option>
<option value="659">NGV NMM4</option>
<option value="658">NGV NMM5</option>
<option value="323">NGV NONG KHAE สวนกล้วย</option>
<option value="650">NGV PMM (Premium Station, Bangna-Trad Km.13)</option>
<option value="383">NGV Sabjareon</option>
<option value="649">NGV SAWADSIRI (NGV - KK2)</option>
<option value="394">NGV SCG</option>
<option value="527">NGV Siam Best</option>
<option value="586">NGV Siam Powerlist</option>
<option value="390">NGV SUK SOMKIAT</option>
<option value="646">NGV SUWANAPOOM (NGV - SVB1)</option>
<option value="380">NGV TPIPL</option>
<option value="635">NGV TRANSPORT บขส</option>
<option value="379">NGV TRUCK SALES</option>
<option value="631">NGV UNION BUS (Siamrajtanee)</option>
<option value="644">NGV UNION BUS SERVICE (NGV-UNB)</option>
<option value="641">NGV VENUS</option>
<option value="591">NGV กองร้อยลาดตระเวน</option>
<option value="589">NGV กำแพงเพชรปิโตรเลียม</option>
<option value="566">NGV ชัยพัฒนา</option>
<option value="555">NGV นครปฐม</option>
<option value="581">NGV บางจาก</option>
<option value="582">NGV พระประแดงปิโตรเลียม</option>
<option value="592">NGV พึ่งสุข PS</option>
<option value="554">NGV มาลัยแมน 1</option>
<option value="556">NGV มาลัยแมน 2</option>
<option value="640">NGV อ่อนนุชขาเข้า</option>
<option value="583">NGV เอกสุขสวัสดิ์</option>
<option value="401">NGV. MASTER KAENGKHOI</option>
<option value="511">NGV. มาบข่า</option>
<option value="519">NGV. วราพร</option>
<option value="522">NGV.เก้าก้อง</option>
<option value="509">NGV.บ้านค่าย</option>
<option value="513">NGV.ระยอง</option>
<option value="524">NGV.ศรีราชา</option>
<option value="525">NGV.ศิริวัฒนา</option>
<option value="526">NGV.สิทธาพร</option>
<option value="506">NPM</option>
<option value="149">NR1</option>
<option value="158">NR2</option>
<option value="150">NRMR</option>
<option value="100">NS1</option>
<option value="101">NS2</option>
<option value="633">Pipeline to Bus Terminal (บขส.)</option>
<option value="630">Pipeline to Green Spot</option>
<option value="645">Pipeline to NGV-SVB1, NGV-SVB2</option>
<option value="453">PTT</option>
<option value="489">PTT GC 2 (NPC)</option>
<option value="497">PTT GC3(TOC)</option>
<option value="492">PTT GC6 (RRC)</option>
<option value="501">PTT MCC</option>
<option value="309">PTT OC</option>
<option value="119">RA1</option>
<option value="120">RA2</option>
<option value="121">RA3</option>
<option value="122">RA4</option>
<option value="123">RA5</option>
<option value="37">RA6</option>
<option value="145">RA7</option>
<option value="146">RA8</option>
<option value="147">RA9</option>
<option value="179">Rangsit MR</option>
<option value="172">RBMR</option>
<option value="173">RBPP</option>
<option value="563">RC4450 - NGV Southern Bus terminal (KP.26.602)</option>
<option value="498">Region3</option>
<option value="89">RJ1</option>
<option value="165">RJP</option>
<option value="512">ROC</option>
<option value="174">RPCL PP</option>
<option value="654">SARNTI</option>
<option value="562">SB#2 - NGV Ratchapluek</option>
<option value="561">SB#2 - NGV Susco Ratchapluek</option>
<option value="564">SB#3 - NGV</option>
<option value="569">SB#4 โรงงานสุนธรเมทัล</option>
<option value="571">SB#6 NGV ทุ่งครุ</option>
<option value="38">SB1</option>
<option value="124">SB2</option>
<option value="125">SB3</option>
<option value="126">SB4</option>
<option value="127">SB5</option>
<option value="128">SB6</option>
<option value="177">SCS</option>
<option value="543">SIAMESE MERCHANDISE PROJECT</option>
<option value="222">Soomboon Somics (SSMC)</option>
<option value="691">SSMC2</option>
<option value="162">SSUT</option>
<option value="35">TECO MR</option>
<option value="697">TGCI COGEN</option>
<option value="520">Thai steel Profile</option>
<option value="503">TNS</option>
<option value="494">TPC-PR</option>
<option value="507">Unity</option>
<option value="95">WK1</option>
<option value="96">WK2</option>
<option value="97">WK3</option>
<option value="98">WK4</option>
<option value="99">WK5</option>
<option value="57">WN1</option>
<option value="30">WN2</option>
<option value="29">WN3</option>
<option value="28">WN4</option>
<option value="26">WN5</option>
<option value="27">WNMR</option>
<option value="442">โครงการวางท่อไปยัง บ.เหล็กสยาม ยาโมโตะ</option>
<option value="369">จากกลางทุ่งไป RABT</option>
<option value="475">เจริญโภคภัณฑ์ปิโตรเคมี</option>
<option value="404">ช่วงที่2 ต่อจากหน้าบ้านบัวภา</option>
<option value="576">ถนนสุขสวัสดิ์</option>
<option value="326">ท่อ Inlet M/R ศูนย์วิจัย ปตท.</option>
<option value="328">ท่อ Outlet M/R ศูนย์วิจัยฯ</option>
<option value="495">ท่อเข้า BST</option>
<option value="596">ท่อรังสิต - ปทุมธานี</option>
<option value="528">ท่อและสถานีก๊าซนิคมRIL.2</option>
<option value="572">ไทยเซนทรัลเคมี TCCC (KP.4.720)</option>
<option value="366">นิคมอุตสาหกรรม หนองแค</option>
<option value="268">นิคมอุตสาหกรรมแหลมฉบัง</option>
<option value="219">นิคมอุตสาหกรรมอีสเทิร์นซีบอร์ด</option>
<option value="493">แนวท่อริมถนนไอ 8</option>
<option value="393">บ.บางกอกโปรดิวส์ BKP 1</option>
<option value="389">บ.บางกอกโปรดิวส์ BKP 2</option>
<option value="392">บ.บางกอกโปรดิวส์ BKP 3-4</option>
<option value="237">บริษัท Chalybs Cylinder </option>
<option value="550">บริษัท กรไทย จำกัด</option>
<option value="204">บริษัท กระจกไทยอาซาฮี จำกัด (มหาชน)</option>
<option value="398">บริษัท กระเบื้องกระดาษไทย จำกัด</option>
<option value="600">บริษัท กรีนสปอต จำกัด</option>
<option value="541">บริษัท กังวาลเท็กซ์ไทล์ จำกัด</option>
<option value="335">บริษัท การ์เดียนอินดัสทรีส์ คอร์ป จำกัด (สระบุรี)</option>
<option value="213">บริษัท เกทส์ ยูนิทตะ (ประเทศไทย) จำกัด</option>
<option value="466">บริษัท โกรเวล แอบเบรซีพ (ไทยแลนด์) จำกัด</option>
<option value="285">บริษัท ควอลิตี้ คอฟฟี่ โปรดักท์ส จำกัด</option>
<option value="517">บริษัท คอทโก้ เอ็นซีอาร์ เปเปอร์ จำกัด</option>
<option value="482">บริษัท คอทโก้-เอสวี อีสเทอร์นสตีลไพพ์ จำกัด</option>
<option value="399">บริษัท คอนวูด จำกัด</option>
<option value="205">บริษัท คาร์ดิแนล เฮลท์ 222 (ประเทศไทย) จำกัด</option>
<option value="225">บริษัท คิริว (ประเทศไทย) จำกัด</option>
<option value="378">บริษัท เคนไซซีรามิคส์ อินดัสตรี้ จำกัด</option>
<option value="414">บริษัท เคอร่าไทล์ เซรามิก จำกัด</option>
<option value="203">บริษัท เคียวเด็น (ประเทศไทย) จำกัด</option>
<option value="202">บริษัท โคนิทซ์ เอเชีย จำกัด</option>
<option value="385">บริษัท โคห์เลอร์ (ประเทศไทย) จำกัด (มหาชน)</option>
<option value="549">บริษัท ไคฮาระ (ประเทศไทย) จำกัด</option>
<option value="200">บริษัท จี เจ สตีล จำกัด (มหาชน)</option>
<option value="476">บริษัท จี สตีล จำกัด (มหาชน)</option>
<option value="685">บริษัท เจลลี เบลลี แคนดี้ คอมปานี (ประเทศไทย) จำก</option>
<option value="234">บริษัท เจลลี เบลลี แคนดี้ คอมปานี (ประเทศไทย) จำกัด</option>
<option value="485">บริษัท ซังโกะ ไดคาชติ้ง (ประเทศไทย) จำกัด (มหาชน)</option>
<option value="270">บริษัท ซัมมิท โชว่าแมนูแฟคเจอริ่ง จำกัด</option>
<option value="381">บริษัท ซีพี-เมจิ จำกัด</option>
<option value="690">บริษัท ซีพีเอฟ (ประเทศไทย) ผลิตภัณฑ์อาหาร จำกัด (</option>
<option value="684">บริษัท ซีพีเอฟ (ประเทศไทย) ผลิตภัณฑ์อาหาร จำกัด (มหาชน)</option>
<option value="613">บริษัท ซีพีเอฟ ผลิตภัณฑ์อาหาร จำกัด</option>
<option value="470">บริษัท ซีอาร์ที ดิสเพลย์ เทคโนโลยี จำกัด</option>
<option value="350">บริษัท เซรามิค อุตสาหกรรมไทย จำกัด</option>
<option value="360">บริษัท เซรามิคอุตสาหกรรมไทย จำกัด</option>
<option value="463">บริษัท เซ้าท์ ซิตี้ ปิโตรเคม จำกัด</option>
<option value="438">บริษัท ไซเทค อินดัสตรีส์ (ประเทศไทย) จำกัด</option>
<option value="700">บริษัท ไซเทค อินดัสตรีส์ จำกัด CYTEX</option>
<option value="352">บริษัท โตโต้ แมนูแฟคเจอรี่ง (ประเทศไทย) จำกัด</option>
<option value="696">บริษัท ที.ที. เซรามิค จำกัด TTCC</option>
<option value="376">บริษัท ที.ที.เซรามิค จำกัด</option>
<option value="464">บริษัท ทุนเท็กซ์ เท็กซ์ไทล์ (ประเทศไทย) จำกัด</option>
<option value="254">บริษัท ไทเท็กซ์ เอเซีย จำกัด</option>
<option value="357">บริษัท ไทย เกลซ อุตสาหกรรม จำกัด</option>
<option value="423">บริษัท ไทย จีซีไอ เรซิท็อป จำกัด</option>
<option value="346">บริษัท ไทย มาลายา กลาส จำกัด</option>
<option value="429">บริษัท ไทย เอ็มเอฟซี จำกัด</option>
<option value="462">บริษัท ไทยคอปเปอร์อินดัสตรี่ จำกัด (มหาชน)</option>
<option value="688">บริษัท ไทยคูนเวิลด์ไวด์กรุ๊ป (ประเทศไทย) จำกัด (ม</option>
<option value="681">บริษัท ไทยคูนเวิลด์ไวด์กรุ๊ป (ประเทศไทย) จำกัด (มหาชน)</option>
<option value="574">บริษัท ไทยเคมีภัณฑ์ จำกัด</option>
<option value="267">บริษัท ไทยซัมซุง อิเลคโทนิคส์ จำกัด</option>
<option value="266">บริษัท ไทยซิลิเกตเคมิคัล จำกัด</option>
<option value="455">บริษัท ไทยแทฟฟิต้า จำกัด</option>
<option value="325">บริษัท ไทยบริดจสโตน จำกัด</option>
<option value="338">บริษัท ไทยเบเวอร์เรจแคน จำกัด</option>
<option value="395">บริษัท ไทยเปอร์อ๊อกไซด์ จำกัด</option>
<option value="486">บริษัท ไทยผลิตภัณฑ์สัปปะรดและผลไม้อื่นๆ จำกัด</option>
<option value="417">บริษัท ไทยพลาสติกและเคมีภัณฑ์ จำกัด (มหาชน)</option>
<option value="207">บริษัท ไทยเพรซิเดนท์ฟูดส์ จำกัด (มหาชน)</option>
<option value="460">บริษัท ไทยฟิล์มอินดัสตรี่ จำกัด (มหาชน)</option>
<option value="354">บริษัท ไทยมาลายา กลาส จำกัด (โรงใหม่)</option>
<option value="275">บริษัท ไทย-เยอรมัน สเปเชียลตี้ กลาส จำกัด</option>
<option value="698">บริษัท ไทย-เยอรมันเซรามิค อินดัสทรี่ จำกัด (มหาชน</option>
<option value="351">บริษัท ไทยเรยอน จำกัด (มหาชน)</option>
<option value="426">บริษัท ไทยไวร์โพรดัคท์ จำกัด (มหาชน)</option>
<option value="427">บริษัท ไทย-สแกนดิคสตีล จำกัด</option>
<option value="701">บริษัท ไทยอะครีลิค จำกัด TAC</option>
<option value="365">บริษัท ไทล์ท้อป อินดัสตรี้ จำกัด (มหาชน)</option>
<option value="246">บริษัท ธนอินเตอร์ จำกัด</option>
<option value="347">บริษัท นอริตาเก้ เอสซีจี พาสเตอร์ จำกัด</option>
<option value="695">บริษัท นิเด็ค บริลเลียน พรีซีชั่น (ไทยแลนด์) จำกั</option>
<option value="286">บริษัท นูทริกซ์ จำกัด</option>
<option value="431">บริษัท โนวา พี.เอ็ม. สตีล จำกัด</option>
<option value="432">บริษัท โนวา สตีล จำกัด</option>
<option value="484">บริษัท บริดจสโตน คาร์บอน แบล็ค (ประเทศไทย) จำกัด</option>
<option value="702">บริษัท บางกอกกล๊าส จำกัด BGI2</option>
<option value="459">บริษัท บางกอกคริสตัล จำกัด</option>
<option value="479">บริษัท บางกอกโพลีเอสเตอร์ จำกัด (มหาชน)</option>
<option value="559">บริษัท บางจากปิโตรเลียม จำกัด (มหาชน)</option>
<option value="199">บริษัท บี เอ็น เอส เอส สตีลกรุ๊ป จำกัด</option>
<option value="602">บริษัท เบอร์ลี่ยุคเกอร์ เซลล๊อกซ์ จำกัด</option>
<option value="416">บริษัท เปอร์ร๊อกซี่ไทย จำกัด</option>
<option value="587">บริษัท ผลิตไฟฟ้าและพลังงานร่วม จำกัด</option>
<option value="400">บริษัท ผลิตภัณฑ์ตราเพชร จำกัด (มหาชน)</option>
<option value="686">บริษัท ผลิตภัณฑ์ตราเพชร จำกัด (มหาชน) (โรงใหม่ แก</option>
<option value="675">บริษัท ผลิตภัณฑ์ตราเพชร จำกัด (มหาชน) (โรงใหม่ แก่งคอยขาเข้า)</option>
<option value="599">บริษัท ฝาจีบ จำกัด (มหาชน)</option>
<option value="276">บริษัท พ้อตเตอร์ส (ประเทศไทย) จำกัด</option>
<option value="260">บริษัท พี เอส เมททอลเวอกส์ จำกัด</option>
<option value="253">บริษัท พีคิว เคมิคอลส์ (ประเทศไทย) จำกัด</option>
<option value="533">บริษัท พีทีที โกลบอล เคมิคอล จำกัด (มหาชน)</option>
<option value="449">บริษัท พูแรค (ประเทศไทย) จำกัด</option>
<option value="457">บริษัท โพสโค-ไทยน๊อคซ์ จำกัด (มหาชน)</option>
<option value="239">บริษัท ฟู้ดแอนด์ดริ๊งส์ จำกัด (มหาชน)</option>
<option value="403">บริษัท ฟูรูกาวา เม็ททัล (ไทยแลนด์) จํากัด (มหาชน)</option>
<option value="699">บริษัท ฟูรูกาวา เม็ททัล จำกัด FMT</option>
<option value="331">บริษัท เฟอร์โร (ประเทศไทย) จํากัด</option>
<option value="330">บริษัท ภัทราพอร์ชเลน จำกัด</option>
<option value="269">บริษัท มิตซูบิชิ มอเตอร์ส (ประเทศไทย) จำกัด นิคมอุตสาหกรรมแหลมฉบัง</option>
<option value="467">บริษัท มิตร สตีล จำกัด</option>
<option value="454">บริษัท มิลล์คอน บูรพา จำกัด</option>
<option value="262">บริษัท เมทโซ เปเปอร์ (ประเทศไทย) จำกัด</option>
<option value="692">บริษัท แม็กซิส อินเตอร์เนชั่นแนล (ประเทศไทย) จำกั</option>
<option value="694">บริษัท แมคคีย์ฟู้ดส์ เซอร์วิสเซส (ประเทศไทย) จำกั</option>
<option value="310">บริษัท โมเดอร์น ไดสตัฟส์ แอนด์พิคเมนท์ส จำกัด</option>
<option value="465">บริษัท โมเนียร์ รูฟฟิ่ง จำกัด</option>
<option value="607">บริษัท ไมโครไฟเบอร์อุตสาหกรรม จำกัด</option>
<option value="261">บริษัท ไมย์เออร์ อลูมิเนียม (ประเทศไทย) จำกัด</option>
<option value="258">บริษัท ไมย์เออร์ อินดัสตรีส์ จำกัด</option>
<option value="604">บริษัท ยัสปาลแอนด์ซันส์ จำกัด</option>
<option value="553">บริษัท ยูแซม อินเตอร์กรุ๊ป จำกัด</option>
<option value="468">บริษัท ยูนิตี้ อินดัสเตรียล จำกัด</option>
<option value="386">บริษัท รอยัลปอร์ซเลน จำกัด (มหาชน)</option>
<option value="220">บริษัท ระยองกัลวาไนซิ่ง จำกัด</option>
<option value="446">บริษัท ระยองเพียวริฟายเออร์ จำกัด (มหาชน)</option>
<option value="428">บริษัท ระยองไวร์อินดัสตรีส์ จำกัด (มหาชน)</option>
<option value="545">บริษัท ราชราตัน ไทย ไวร์ จำกัด</option>
<option value="579">บริษัท โรงงานเหล็กกรุงเทพฯ จำกัด</option>
<option value="368">บริษัท โรแยล เซรามิค อุตสาหกรรม จำกัด (มหาชน)</option>
<option value="245">บริษัท ล.ไลท์ติ้งกลาส จำกัด</option>
<option value="548">บริษัท ลักกี้กลาส จำกัด</option>
<option value="420">บริษัท ลาร์พอร์ท จำกัด</option>
<option value="490">บริษัท วินิไทย จำกัด (มหาชน)</option>
<option value="337">บริษัท วิลเลรอย แอนด์ บอค (ประเทศไทย) จำกัด</option>
<option value="272">บริษัท เวลโกรว์กล๊าส อินดัสทรี จำกัด</option>
<option value="612">บริษัท ศานติบรรจุภัณฑ์ จำกัด</option>
<option value="480">บริษัท สตาร์ โซลเลล์ กรุ๊ป จำกัด</option>
<option value="473">บริษัท สตาร์คอร์ จำกัด</option>
<option value="324">บริษัท สตาร์ซานิทารี่แวร์ จำกัด (มหาชน)</option>
<option value="228">บริษัท สตาร์ส เทคโนโลยี อินดัสเตรียล จำกัด</option>
<option value="278">บริษัท สแตนดาร์ดแคน จำกัด</option>
<option value="217">บริษัท สมบูรณ์ โซมิค แมนูแฟคเจอริ่ง จำกัด</option>
<option value="259">บริษัท สยาม พุงซาน เมทัล จำกัด</option>
<option value="471">บริษัท สยาม ลวดเหล็กอุตสาหกรรม จำกัด</option>
<option value="343">บริษัท สยาม เอ็นจีเค เทคโนเซรา จำกัด</option>
<option value="247">บริษัท สยามโกโก้โปรดักส์ จำกัด</option>
<option value="251">บริษัท สยามคอมเพรสเซอร์อุตสาหกรรม จำกัด</option>
<option value="342">บริษัท สยามซานิทารี่แวร์ อินดัสทรี (หนองแค) จำกัด</option>
<option value="458">บริษัท สยามนวภัณฑ์ จำกัด</option>
<option value="580">บริษัท สยามบราเดอร์ จำกัด</option>
<option value="430">บริษัท สยามแผ่นเหล็กวิลาส จำกัด</option>
<option value="542">บริษัท สยามพรีเสิร์ฟ ฟู้ดส์ จำกัด</option>
<option value="340">บริษัท สยามฟูรูกาวา จำกัด</option>
<option value="336">บริษัท สยามไฟเบอร์กลาส จำกัด</option>
<option value="469">บริษัท สยามมิชลิน จำกัด</option>
<option value="618">บริษัท สยามร่วมมิตร จำกัด โรงงาน 1</option>
<option value="349">บริษัท สยามเลมเมอร์ซ จำกัด</option>
<option value="477">บริษัท สยามอุตสาหกรรมเกษตรอาหาร จำกัด (มหาชน)</option>
<option value="341">บริษัท สยามอุตสาหกรรมยิบซัม (สระบุรี) จำกัด</option>
<option value="284">บริษัท สหวิริยาเพลทมิล จำกัด</option>
<option value="577">บริษัท สายไฟฟ้าไทย-ยาซากิ จำกัด</option>
<option value="282">บริษัท สายไฟฟ้าบางกอกเคเบิ้ล จำกัด</option>
<option value="474">บริษัท แสงไทยเมตัลดรัม จำกัด</option>
<option value="332">บริษัท โสสุโก้เซรามิค จำกัด</option>
<option value="248">บริษัท หลุยส์ผลิตภัณท์กาวเทป จำกัด</option>
<option value="424">บริษัท เหล็กก่อสร้างสยาม จำกัด</option>
<option value="687">บริษัท อดิตยา เบอร์ล่า เคมีคัลส์ (ประเทศไทย) จำกั</option>
<option value="679">บริษัท อดิตยา เบอร์ล่า เคมีคัลส์ (ประเทศไทย) จำกัด (คลออัลคาลีดีวิชั่น)</option>
<option value="680">บริษัท อดิตยา เบอร์ล่า เคมีคัลส์ (ประเทศไทย) จำกัด (อีพอกซี่)</option>
<option value="206">บริษัท อมตะพาวเวอร์ จำกัด</option>
<option value="689">บริษัท อเมริกันสแตนดาร์ด บีแอนด์เค (ประเทศไทย) จำ</option>
<option value="598">บริษัท อเมริกันสแตนดาร์ด บีแอนด์เค (ประเทศไทย) จำกัด (มหาชน)</option>
<option value="197">บริษัท อลูคอน จำกัด (มหาชน)</option>
<option value="578">บริษัท อลูมิเนียม ฉื่อ จิ้น ฮั้ว จำกัด</option>
<option value="373">บริษัท อายิโนะโมะโต๊ะ (ประเทศไทย) จำกัด</option>
<option value="377">บริษัท อายิโนะโมะโต๊ะ เซลส์ (ประเทศไทย) จำกัด</option>
<option value="223">บริษัท อาร์พีที เอเชีย จำกัด</option>
<option value="448">บริษัท อินโดรามา ปิโตรเคม จำกัด</option>
<option value="418">บริษัท อิวอนิก ยูไนเต็ด ซิลิกา (สยาม) จำกัด</option>
<option value="472">บริษัท อีเลคโทรลักซ์ประเทศไทย จำกัด</option>
<option value="609">บริษัท อีสเทิร์นไชน่าแวร์ จำกัด</option>
<option value="703">บริษัท อีสเทิร์นไชน่าแวร์ จำกัด ETC</option>
<option value="461">บริษัท อีโอซีโพลิเมอร์ส (ไทยแลนด์) จำกัด</option>
<option value="256">บริษัท เอ.เจ. พลาสท์ จำกัด (มหาชน)</option>
<option value="551">บริษัท เอเชี่ยน สุพีเรียฟู้ดส์ จำกัด</option>
<option value="481">บริษัท เอ็น ซี อาร์ รับเบอร์อินดัสตรี้ จำกัด</option>
<option value="198">บริษัท เอ็น.ที.เอส. สตีลกรุ๊ป จำกัด (มหาชน)</option>
<option value="356">บริษัท เอ็นเนซอล จำกัด</option>
<option value="478">บริษัท เอเพ็คปิโตรเคมิคอล จำกัด</option>
<option value="271">บริษัท เอส ที บี เท็กซ์ไทล์ อินดัสตรี จำกัด</option>
<option value="257">บริษัท เอส เอ็น ซี ฟอร์เมอร์ จำกัด (มหาชน)</option>
<option value="214">บริษัท เอส ไอ ดับบลิว (ไทยแลนด์) จำกัด</option>
<option value="433">บริษัท เอสอาร์เอฟ อินดัสตรี้ส์ (ไทยแลนด์) จำกัด</option>
<option value="322">บริษัท โอสถสภา จำกัด</option>
<option value="421">บริษัท โอเอสซี สยามซิลิกา จำกัด</option>
<option value="535">บริษัท ไออาร์พีซี จำกัด (มหาชน)</option>
<option value="327">บริษัท ไฮเจน เพาเวอร์ จำกัด</option>
<option value="510">แยก กม.12 ไป TYCONs (6")</option>
<option value="678">ระบบท่อส่งก๊าซฯไปยังบริษัท NPC</option>
<option value="419">โรงไฟฟ้า บางกอกโคเจเนอเรชั่น</option>
<option value="683">โรงไฟฟ้าบีกริม</option>
<option value="499">วนชัย</option>
<option value="422">ศักดิ์ไชยสิทธิ</option>
<option value="560">สวนอุตสาหกรรม บางกระดี</option>
<option value="241">สวนอุตสาหกรรมโรจนะ (ระยอง)</option>
<option value="570">สุนทรเมทัล อินดัสทรี้ส์ จำกัด  บางบอน กรุงเทพฯ</option>
<option value="573">เหล่าธงสิงห์ </option>
<option value="447">เอเชียซิลิโคน โมโนเมอร์</option>
</select>
</div>
          </div>

             <div class="col-sm-4">
           <div class="input-group">
  <span class="input-group-addon" id="Span6" >Route Code </span>
   <select name="RouteCode" class="form-control" id="RouteCode"><option selected="selected" value="0">ทั้งหมด</option>
<option value="1163">RC0200</option>
<option value="1164">RC0200101</option>
<option value="866">RC020100</option>
<option value="1165">RC0210</option>
<option value="953">RC0250</option>
<option value="954">RC0250</option>
<option value="955">RC0260</option>
<option value="956">RC0260</option>
<option value="867">RC032010</option>
<option value="868">RC033000</option>
<option value="957">RC03301</option>
<option value="958">RC03301</option>
<option value="959">RC03301</option>
<option value="869">RC033010</option>
<option value="960">RC0330100001</option>
<option value="961">RC0330100003</option>
<option value="962">RC0330100004</option>
<option value="963">RC0330200002</option>
<option value="964">RC03303</option>
<option value="965">RC0330300001</option>
<option value="966">RC0330300005</option>
<option value="967">RC0330300009</option>
<option value="968">RC0330400001</option>
<option value="969">RC0330400004</option>
<option value="970">RC0330400005</option>
<option value="971">RC0330401</option>
<option value="1303">RC03305</option>
<option value="972">RC0330500003</option>
<option value="973">RC0330500004</option>
<option value="974">RC0330500005</option>
<option value="975">RC0330500008</option>
<option value="976">RC033050001</option>
<option value="977">RC0330500010</option>
<option value="978">RC0330500011</option>
<option value="1273">RC0330500012</option>
<option value="979">RC0330500012</option>
<option value="980">RC0330500012</option>
<option value="981">RC0330500013</option>
<option value="982">RC033050002</option>
<option value="983">RC0330600001</option>
<option value="984">RC0330600003</option>
<option value="1304">RC0330800104</option>
<option value="1305">RC0330800104</option>
<option value="985">RC033081004</option>
<option value="986">RC0330820005</option>
<option value="987">RC033083010</option>
<option value="988">RC0330830101</option>
<option value="989">RC0330900001</option>
<option value="1306">RC0330901</option>
<option value="990">RC0330901001</option>
<option value="991">RC0330901002</option>
<option value="992">RC0330901003</option>
<option value="993">RC0330901005</option>
<option value="994">RC0340</option>
<option value="995">RC0340</option>
<option value="996">RC03401</option>
<option value="997">RC03402</option>
<option value="998">RC03402101</option>
<option value="999">RC0340210101</option>
<option value="1307">RC0340210102</option>
<option value="1000">RC0340210103</option>
<option value="1001">RC0340210104</option>
<option value="1002">RC0340210106</option>
<option value="1003">RC0340210108</option>
<option value="663">RC0340210109</option>
<option value="1004">RC0340210110</option>
<option value="1005">RC03402102</option>
<option value="1006">RC0340210201</option>
<option value="1007">RC0340210201</option>
<option value="1008">RC0340210202</option>
<option value="1009">RC0340210203</option>
<option value="1010">RC0340210203</option>
<option value="1011">RC0340210204</option>
<option value="1012">RC03402103</option>
<option value="1013">RC03402103</option>
<option value="1014">RC0340210301</option>
<option value="1015">RC0340210302</option>
<option value="1016">RC0340210304</option>
<option value="1017">RC0340210305</option>
<option value="1018">RC0340210306</option>
<option value="1019">RC0340210307</option>
<option value="1020">RC0340210308</option>
<option value="1021">RC0340210309</option>
<option value="1022">RC03402104</option>
<option value="1023">RC03402105</option>
<option value="1024">RC0340210502</option>
<option value="1025">RC03402106</option>
<option value="1026">RC0340210601</option>
<option value="1274">RC0340210601</option>
<option value="1027">RC0340210602</option>
<option value="1028">RC0340210701</option>
<option value="1029">RC0340300001</option>
<option value="1030">RC0340300002</option>
<option value="1031">RC0340301001</option>
<option value="1032">RC0400</option>
<option value="1033">RC0400</option>
<option value="664">RC0400</option>
<option value="665">RC0400</option>
<option value="666">RC0400</option>
<option value="667">RC0400</option>
<option value="1034">RC0401100001</option>
<option value="1308">RC040110001</option>
<option value="1035">RC0401110002</option>
<option value="1036">RC040112001</option>
<option value="668">RC0402110001</option>
<option value="669">RC0402110101</option>
<option value="1277">RC0402110102</option>
<option value="670">RC0402110103</option>
<option value="671">RC0402110105</option>
<option value="672">RC0402110106</option>
<option value="673">RC04022</option>
<option value="674">RC04022</option>
<option value="675">RC0402200001</option>
<option value="676">RC0402210001</option>
<option value="677">RC0402210002</option>
<option value="678">RC0402210003</option>
<option value="679">RC0402210003</option>
<option value="680">RC0402210003</option>
<option value="681">RC0402210003</option>
<option value="682">RC0402210101</option>
<option value="683">RC04022102002</option>
<option value="684">RC04022102003</option>
<option value="685">RC0402211001</option>
<option value="686">RC040222012</option>
<option value="687">RC040231</option>
<option value="1278">RC0402310102</option>
<option value="688">RC04023301</option>
<option value="1279">RC0402330102</option>
<option value="689">RC04023302</option>
<option value="1280">RC0402330201</option>
<option value="1281">RC0402330205</option>
<option value="690">RC0402330205</option>
<option value="691">RC0402330205</option>
<option value="692">RC04023304</option>
<option value="693">RC0402330502</option>
<option value="1282">RC0402330606</option>
<option value="1283">RC0402330608</option>
<option value="1270">RC04023307</option>
<option value="694">RC04023307</option>
<option value="1284">RC04023309</option>
<option value="695">RC0402340101</option>
<option value="1285">RC04030101</option>
<option value="696">RC04030301</option>
<option value="697">RC040304</option>
<option value="698">RC040305</option>
<option value="699">RC04031</option>
<option value="700">RC04031</option>
<option value="701">RC04032</option>
<option value="702">RC04032</option>
<option value="1037">RC04032102</option>
<option value="1038">RC0403210201</option>
<option value="1039">RC0403210202</option>
<option value="1040">RC04032201</option>
<option value="703">RC0403301001</option>
<option value="704">RC0405100001</option>
<option value="705">RC0405110101</option>
<option value="1286">RC0405110102</option>
<option value="706">RC0405110103</option>
<option value="707">RC04052</option>
<option value="1041">RC0430</option>
<option value="1042">RC04302</option>
<option value="708">RC04311</option>
<option value="709">RC0431110003</option>
<option value="710">RC0431110003</option>
<option value="711">RC0431110104</option>
<option value="712">RC04311103</option>
<option value="713">RC04311103</option>
<option value="714">RC0431120001</option>
<option value="715">RC0431120002</option>
<option value="716">RC0431120002</option>
<option value="1287">RC04311201</option>
<option value="1288">RC04311201</option>
<option value="1289">RC04311201</option>
<option value="717">RC0431120101</option>
<option value="718">RC0431120102</option>
<option value="719">RC0431120102</option>
<option value="720">RC0431120103</option>
<option value="721">RC0431120103</option>
<option value="722">RC0431120105</option>
<option value="723">RC0431120105</option>
<option value="724">RC0431120106</option>
<option value="725">RC0431120107</option>
<option value="726">RC0431120108</option>
<option value="727">RC0431120108</option>
<option value="1043">RC043301001</option>
<option value="1044">RC043301002</option>
<option value="1045">RC043301003</option>
<option value="728">RC0440</option>
<option value="729">RC0440</option>
<option value="730">RC04401</option>
<option value="731">RC0440210002</option>
<option value="732">RC0440220001</option>
<option value="733">RC0440230001</option>
<option value="734">RC04403</option>
<option value="735">RC044042</option>
<option value="736">RC04404201</option>
<option value="737">RC04405</option>
<option value="738">RC04450103</option>
<option value="739">RC04450103</option>
<option value="740">RC04450103</option>
<option value="741">RC04450104</option>
<option value="742">RC04450104</option>
<option value="743">RC04450105</option>
<option value="744">RC04450105</option>
<option value="745">RC04501</option>
<option value="746">RC04502</option>
<option value="1046">RC0460</option>
<option value="1047">RC0460</option>
<option value="747">RC0460</option>
<option value="748">RC0460</option>
<option value="749">RC0460</option>
<option value="750">RC0460</option>
<option value="751">RC0460</option>
<option value="752">RC0460</option>
<option value="753">RC046402</option>
<option value="754">RC04641</option>
<option value="755">RC046501</option>
<option value="756">RC046502</option>
<option value="757">RC046601</option>
<option value="1119">RC0500</option>
<option value="758">RC0500</option>
<option value="759">RC0500</option>
<option value="760">RC0500</option>
<option value="761">RC0500</option>
<option value="762">RC0500</option>
<option value="763">RC0500</option>
<option value="1290">RC0503100002</option>
<option value="764">RC0503100004</option>
<option value="1291">RC0503200001</option>
<option value="765">RC05033</option>
<option value="766">RC0503301</option>
<option value="767">RC050401</option>
<option value="768">RC050404</option>
<option value="769">RC05040402</option>
<option value="1292">RC05041</option>
<option value="1293">RC0504200001</option>
<option value="770">RC050504</option>
<option value="771">RC050504</option>
<option value="772">RC0505301001</option>
<option value="773">RC0505301002</option>
<option value="1120">RC050611</option>
<option value="1121">RC05062</option>
<option value="1122">RC0506201</option>
<option value="774">RC0520</option>
<option value="1311">RC0561200001</option>
<option value="1182">RC061780101</option>
<option value="1183">RC061780104</option>
<option value="1184">RC0620</option>
<option value="1185">RC0620</option>
<option value="1186">RC06202</option>
<option value="1275">RC06202</option>
<option value="1187">RC06203</option>
<option value="1188">RC062030004</option>
<option value="1189">RC06203004</option>
<option value="1190">RC0620501</option>
<option value="1191">RC06206</option>
<option value="1192">RC06208</option>
<option value="1193">RC0620801001</option>
<option value="1194">RC0620801002</option>
<option value="1195">RC0630</option>
<option value="1196">RC0630</option>
<option value="1197">RC0630</option>
<option value="775">RC0630</option>
<option value="776">RC0630</option>
<option value="777">RC0630</option>
<option value="827">RC0630</option>
<option value="778">RC06311</option>
<option value="779">RC06311</option>
<option value="780">RC06311</option>
<option value="781">RC06311</option>
<option value="1294">RC0631100002</option>
<option value="782">RC0631100005</option>
<option value="783">RC0631100006</option>
<option value="784">RC06321</option>
<option value="785">RC06321</option>
<option value="786">RC06321002</option>
<option value="787">RC063210101</option>
<option value="1198">RC06322101</option>
<option value="788">RC06322102</option>
<option value="789">RC06322103</option>
<option value="790">RC06322104</option>
<option value="1199">RC06330102</option>
<option value="1200">RC06340101</option>
<option value="1201">RC06340102</option>
<option value="1276">RC06340102</option>
<option value="828">RC063601</option>
<option value="829">RC063601</option>
<option value="830">RC063601</option>
<option value="831">RC06360101</option>
<option value="832">RC06360106</option>
<option value="833">RC063602</option>
<option value="1202">RC0650</option>
<option value="1203">RC0650</option>
<option value="1204">RC0650</option>
<option value="1205">RC0650</option>
<option value="1206">RC0650</option>
<option value="1207">RC0650</option>
<option value="1208">RC0650</option>
<option value="791">RC0650</option>
<option value="834">RC0650</option>
<option value="1312">RC06505</option>
<option value="1209">RC0651100001</option>
<option value="1210">RC0651100004</option>
<option value="1211">RC0651300004</option>
<option value="1212">RC06514</option>
<option value="1213">RC06520101</option>
<option value="1214">RC06520102</option>
<option value="1215">RC065202</option>
<option value="1216">RC06520202</option>
<option value="1217">RC06521</option>
<option value="1218">RC0652200002</option>
<option value="1313">RC06523</option>
<option value="1314">RC06523</option>
<option value="1219">RC065231001</option>
<option value="1220">RC0652501</option>
<option value="1221">RC0652501001</option>
<option value="1222">RC0652501002</option>
<option value="1223">RC06527</option>
<option value="1224">RC06528</option>
<option value="1225">RC0652901001</option>
<option value="1226">RC0653020001</option>
<option value="1227">RC065303</option>
<option value="1228">RC0653040101</option>
<option value="1229">RC0653050001</option>
<option value="1230">RC0653050002</option>
<option value="1231">RC065306</option>
<option value="1232">RC0653060001</option>
<option value="1233">RC0653060002</option>
<option value="1234">RC0653060003</option>
<option value="1235">RC06530701</option>
<option value="1236">RC06530702</option>
<option value="1237">RC065308</option>
<option value="1238">RC06531</option>
<option value="1239">RC0653100004</option>
<option value="1240">RC0653110108</option>
<option value="1315">RC0653110202</option>
<option value="1241">RC0654101001</option>
<option value="1242">RC0654201001</option>
<option value="1243">RC06550301001</option>
<option value="1244">RC065505</option>
<option value="1245">RC065506</option>
<option value="1246">RC0655101001</option>
<option value="1316">RC0655101001</option>
<option value="1247">RC0655201001</option>
<option value="1248">RC06561</option>
<option value="835">RC065804</option>
<option value="1295">RC065811</option>
<option value="836">RC0658110001</option>
<option value="837">RC06582</option>
<option value="838">RC065821</option>
<option value="839">RC06582101</option>
<option value="840">RC065823</option>
<option value="841">RC0660</option>
<option value="842">RC0660</option>
<option value="843">RC0660</option>
<option value="844">RC0661110002</option>
<option value="845">RC0661110004</option>
<option value="846">RC06611102</option>
<option value="847">RC066112</option>
<option value="848">RC0661120001</option>
<option value="849">RC0661120002</option>
<option value="850">RC0661120003</option>
<option value="851">RC0661120004</option>
<option value="1296">RC0661120005</option>
<option value="852">RC06611201</option>
<option value="853">RC0661120101</option>
<option value="854">RC0661120104</option>
<option value="855">RC0661120105</option>
<option value="856">RC0661120109</option>
<option value="857">RC0661120110</option>
<option value="858">RC0661120202</option>
<option value="859">RC0661120203</option>
<option value="860">RC0661120401</option>
<option value="861">RC06611205</option>
<option value="862">RC0661120502</option>
<option value="863">RC06611206</option>
<option value="864">RC06613</option>
<option value="1297">RC06614</option>
<option value="865">RC06615001</option>
<option value="872">RC0664010001</option>
<option value="873">RC0664010002</option>
<option value="874">RC0670</option>
<option value="875">RC0670</option>
<option value="876">RC0670</option>
<option value="877">RC0670</option>
<option value="878">RC0670</option>
<option value="813">RC06710601</option>
<option value="879">RC067111001</option>
<option value="880">RC067111002</option>
<option value="881">RC0671200001</option>
<option value="882">RC067121</option>
<option value="883">RC0671210002</option>
<option value="884">RC06712101</option>
<option value="885">RC0671210101</option>
<option value="886">RC0671210102</option>
<option value="887">RC0671210104</option>
<option value="888">RC06712102</option>
<option value="889">RC0671210202</option>
<option value="1298">RC0671210301</option>
<option value="1299">RC0671210301</option>
<option value="890">RC06712104</option>
<option value="1300">RC067122</option>
<option value="1301">RC067122</option>
<option value="891">RC0671300001</option>
<option value="892">RC0671400001</option>
<option value="893">RC0671500001</option>
<option value="894">RC067201</option>
<option value="895">RC067210001</option>
<option value="896">RC067210002</option>
<option value="897">RC067220001</option>
<option value="898">RC067301</option>
<option value="1272">RC06730101</option>
<option value="899">RC06730101</option>
<option value="900">RC067302</option>
<option value="901">RC06731</option>
<option value="902">RC067311</option>
<option value="903">RC0673110001</option>
<option value="904">RC0673110002</option>
<option value="905">RC0673110003</option>
<option value="906">RC0673110101</option>
<option value="907">RC0673110102</option>
<option value="908">RC0673110104</option>
<option value="909">RC0673110105</option>
<option value="910">RC0673120101</option>
<option value="911">RC06732</option>
<option value="912">RC0673200001</option>
<option value="913">RC0673200002</option>
<option value="914">RC0673200002</option>
<option value="915">RC0673500001</option>
<option value="916">RC0673600001</option>
<option value="917">RC0673700001</option>
<option value="918">RC0673800001</option>
<option value="919">RC0673900001</option>
<option value="1302">RC06741</option>
<option value="920">RC0674100001</option>
<option value="1249">RC0680</option>
<option value="1250">RC0680</option>
<option value="921">RC0681</option>
<option value="922">RC0690</option>
<option value="923">RC0690</option>
<option value="924">RC0690</option>
<option value="925">RC0690</option>
<option value="926">RC0690</option>
<option value="927">RC0690</option>
<option value="928">RC0690</option>
<option value="929">RC069211</option>
<option value="930">RC06921101</option>
<option value="931">RC0692110101</option>
<option value="932">RC0692110102</option>
<option value="933">RC0692110103</option>
<option value="934">RC069401</option>
<option value="935">RC06940102</option>
<option value="936">RC069501</option>
<option value="937">RC0697</option>
<option value="938">RC0697</option>
<option value="939">RC0697</option>
<option value="940">RC0697</option>
<option value="1082">RC10210101</option>
<option value="1083">RC10210102</option>
<option value="870">RC35010</option>
<option value="871">RC36010</option>
<option value="1084">RC4000</option>
<option value="1085">RC4000</option>
<option value="1086">RC4000</option>
<option value="1087">RC4000</option>
<option value="1088">RC4000</option>
<option value="1089">RC4000</option>
<option value="1169">RC4000</option>
<option value="1170">RC4000</option>
<option value="1171">RC4000</option>
<option value="1172">RC4000</option>
<option value="1173">RC4000</option>
<option value="1174">RC4000</option>
<option value="1175">RC4000</option>
<option value="1176">RC4000</option>
<option value="1177">RC4000</option>
<option value="1178">RC4000</option>
<option value="1179">RC4000</option>
<option value="1251">RC400900001</option>
<option value="655">RC401</option>
<option value="1048">RC40110</option>
<option value="1049">RC401110001</option>
<option value="1050">RC40112</option>
<option value="1051">RC40112002</option>
<option value="1090">RC401201001</option>
<option value="1091">RC401201002</option>
<option value="1092">RC40121</option>
<option value="1093">RC40121</option>
<option value="1094">RC401231</option>
<option value="1095">RC401231</option>
<option value="1096">RC401231</option>
<option value="1052">RC401301001</option>
<option value="1053">RC4014</option>
<option value="1054">RC401402001</option>
<option value="1055">RC4015</option>
<option value="656">RC402</option>
<option value="657">RC403</option>
<option value="658">RC404</option>
<option value="659">RC405</option>
<option value="660">RC406</option>
<option value="661">RC407</option>
<option value="662">RC408</option>
<option value="1097">RC4100</option>
<option value="1098">RC4100</option>
<option value="1099">RC4100</option>
<option value="1100">RC4100</option>
<option value="1101">RC4100</option>
<option value="1102">RC4100</option>
<option value="1123">RC4100</option>
<option value="1124">RC4100</option>
<option value="1252">RC4100</option>
<option value="1253">RC4100</option>
<option value="1254">RC4100</option>
<option value="1255">RC4100</option>
<option value="941">RC4100</option>
<option value="1103">RC410101</option>
<option value="1104">RC41010101</option>
<option value="1105">RC41010102</option>
<option value="1106">RC41010103</option>
<option value="1107">RC410102</option>
<option value="1108">RC41010201</option>
<option value="1109">RC41010202</option>
<option value="1110">RC41010203</option>
<option value="1111">RC41010204</option>
<option value="1112">RC41010205</option>
<option value="1113">RC410103</option>
<option value="1309">RC410201002</option>
<option value="1310">RC410300001</option>
<option value="1114">RC410302001</option>
<option value="1115">RC41041</option>
<option value="1116">RC410410201</option>
<option value="1117">RC410410301</option>
<option value="1118">RC410410401</option>
<option value="1256">RC41071</option>
<option value="1257">RC4108</option>
<option value="1258">RC410901</option>
<option value="1259">RC410903</option>
<option value="1180">RC4300</option>
<option value="1181">RC4310</option>
<option value="1125">RC4450</option>
<option value="1126">RC4450</option>
<option value="1127">RC4450</option>
<option value="1128">RC4450</option>
<option value="1129">RC4450</option>
<option value="1130">RC4450</option>
<option value="1131">RC4450</option>
<option value="1132">RC445201001</option>
<option value="1133">RC445201002</option>
<option value="1134">RC445202</option>
<option value="1135">RC445301</option>
<option value="1136">RC445401001</option>
<option value="1137">RC44540102</option>
<option value="1138">RC445402</option>
<option value="1139">RC445402101</option>
<option value="1140">RC445403</option>
<option value="1141">RC44540301</option>
<option value="1142">RC445601</option>
<option value="1143">RC4457010102</option>
<option value="1144">RC4457010103</option>
<option value="1145">RC4457010105</option>
<option value="1146">RC4457010106</option>
<option value="1147">RC4457010107</option>
<option value="1148">RC4457010108</option>
<option value="1149">RC4457010202</option>
<option value="1150">RC4457010203</option>
<option value="1151">RC4457010204</option>
<option value="1152">RC4457010205</option>
<option value="1153">RC4457010207</option>
<option value="1154">RC4457010208</option>
<option value="1260">RC4470</option>
<option value="1261">RC4470</option>
<option value="1262">RC4470</option>
<option value="1263">RC4470</option>
<option value="1264">RC4470</option>
<option value="1155">RC4500</option>
<option value="1156">RC4500</option>
<option value="1157">RC4500</option>
<option value="1056">RC4900</option>
<option value="1057">RC4900</option>
<option value="1058">RC4900</option>
<option value="1059">RC4900</option>
<option value="792">RC4900</option>
<option value="793">RC4900</option>
<option value="803">RC4900</option>
<option value="804">RC4900</option>
<option value="805">RC4900</option>
<option value="806">RC4900</option>
<option value="807">RC4900</option>
<option value="808">RC4900</option>
<option value="809">RC4900</option>
<option value="810">RC4900</option>
<option value="811">RC4900</option>
<option value="812">RC4900</option>
<option value="942">RC4900</option>
<option value="943">RC4900</option>
<option value="944">RC4900</option>
<option value="945">RC4900</option>
<option value="1060">RC5200</option>
<option value="1061">RC5200</option>
<option value="1062">RC5600</option>
<option value="1063">RC5600</option>
<option value="1064">RC5600</option>
<option value="1065">RC5600</option>
<option value="1066">RC5600</option>
<option value="794">RC5600</option>
<option value="795">RC5600</option>
<option value="796">RC5600</option>
<option value="797">RC5600</option>
<option value="798">RC5600</option>
<option value="1067">RC56010101</option>
<option value="1068">RC56010103</option>
<option value="1069">RC560140201</option>
<option value="799">RC56051101</option>
<option value="800">RC560601</option>
<option value="1070">RC5610</option>
<option value="1071">RC5610</option>
<option value="1072">RC5610</option>
<option value="1073">RC5610</option>
<option value="1074">RC5611</option>
<option value="1075">RC561201</option>
<option value="1076">RC56120101</option>
<option value="1077">RC561401</option>
<option value="801">RC565101</option>
<option value="802">RC56510101</option>
<option value="1166">RC5810</option>
<option value="1167">RC5810</option>
<option value="1168">RC581101</option>
<option value="1078">RC5910</option>
<option value="1079">RC5910</option>
<option value="1080">RC5930</option>
<option value="1081">RC5930</option>
<option value="1265">RC6100</option>
<option value="1158">RC61520101</option>
<option value="1159">RC61520102</option>
<option value="1160">RC61610102</option>
<option value="1161">RC61610103</option>
<option value="1162">RC61780103</option>
<option value="1271">RC6700</option>
<option value="814">RC6700</option>
<option value="815">RC6700</option>
<option value="816">RC6700</option>
<option value="817">RC6700</option>
<option value="818">RC6700</option>
<option value="819">RC6700</option>
<option value="820">RC6700</option>
<option value="821">RC6700</option>
<option value="822">RC6700</option>
<option value="823">RC6700</option>
<option value="824">RC6700</option>
<option value="825">RC6700</option>
<option value="826">RC6700</option>
<option value="946">RC6700</option>
<option value="1266">RC6720</option>
<option value="1267">RC6720</option>
<option value="1268">RC6720</option>
<option value="1269">RC6720</option>
<option value="947">RC6750</option>
<option value="948">RC6750</option>
<option value="949">RC6750</option>
<option value="950">RC6750</option>
<option value="951">RC6750</option>
<option value="952">RC6800</option>
<option value="652">RC70101</option>
<option value="653">RC78000</option>
<option value="654">RC80000</option>
</select>
</div>
          </div>
            
           <div class="col-sm-1">
        <button type="button" class="btn btn-lg btn-primary bthSearch pull-right">ค้นหา</button>
      </div>
          </div>
         
         

            <div class="row" style="padding-top:10px;">

      <div class="col-sm-2"></div>
     
     

       </div>


        <div class="row" style="padding-top:30px;">
          <div class="col-sm-12">
          
    <div class="card ">
           <div class="card-header card-headerBlue">
           <div class="row">
    <div class="col-sm-9">
          <i class="fa fa-file " ></i> Plan 
          </div>
          <div class="col-sm-3">
          
           </div>
          </div>
          </div>
        <div class="card-body">
       <div class="row table-responsive">
       <div class="col-sm-4">
            <table class="table table-bordered list-table" >
                <thead>
                    <tr class="bg-primary">
                        <th colspan="3" class="text-center">จำนวนรายการที่จัดแผน</th>
                    </tr>
                    <tr class="bg-primary">
                        <th>จำนวน BV</th>
                        <th>จำนวน RC</th>
                    </tr>
                </thead>
                <tbody>
                    <tr class="text-center">
                        <td>5</td>
                        <td>4</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="col-sm-8">
            <table class="table table-bordered list-table" >
                <thead>
                    <tr class="bg-primary">
                        <th colspan="8" class="text-center">รายการ Inspection</th>
                    </tr>
                    <tr class="bg-primary">
                        <th>ทั้งหมด</th>
                        <th>เสร็จสิ้น</th>
                        <th>รอดำเนินการ</th>
                        <th>เขต (วิศวกร) ตรวจสอบ</th>
                        <th>ผ./หน. ปท ตรวจสอบ</th>
                        <th>รท.วรก ตรวจสอบ</th>
                        <th>ที่ต้องแก้ไข</th>
                        <th>เลยกำหนด</th>
                    </tr>
                </thead>
                <tbody>
                    <tr class="text-center">
                        <td>
                            <a class="plan-list-link" href="/PipingInspection_test/Inspection/PlanList?type=total">
                                21
                            </a>
                        </td>
                        <td>
                            <a class="plan-list-link" href="/PipingInspection_test/Inspection/PlanList?type=finish">
                                0
                            </a>
                        </td>
                        <td>
                            <a class="plan-list-link" href="/PipingInspection_test/Inspection/PlanList?type=waiting">
                                21
                            </a>
                        </td>
                        <td>
                            <a class="plan-list-link" href="/PipingInspection_test/Inspection/PlanList?type=engineer">
                                0
                            </a>
                        </td>
                        <td>
                            <a class="plan-list-link" href="/PipingInspection_test/Inspection/PlanList?type=manager">
                                0
                            </a>
                        </td>
                        <td>
                            <a class="plan-list-link" href="/PipingInspection_test/Inspection/PlanList?type=rt">
                                0
                            </a>
                        </td>
                        <td>
                            <a class="plan-list-link" href="/PipingInspection_test/Inspection/PlanList?type=resolve">
                                0
                            </a>
                        </td>
                        <td>
                            <a class="plan-list-link" href="/PipingInspection_test/Inspection/PlanList?type=late">
                                9
                            </a>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
       
       </div>
          
          <div class="row">
       
                </div>

               <!-- <div class="row">
                <div class="col-sm-12">
                <table id="table" class="table table-responsive " style="width:100%">
                     <thead>
                            <tr class="bg-primary">
                                <th data-field="region"  colspan="1" style="width:100%">Detail</th>
                               
                            </tr>
                           
                        </thead>
</table>
                </div>
                </div>-->

                <div class="row" >
                <div class="col-sm-12 table-responsive">
                
                <table class="table table-bordered " style="background: rgb(255, 255, 255); width:100%;  margin-bottom: 0px;border-collapse:collapse;">
  
    <tbody>
 

                          <tr class="bg-success accordion-toggle" data-toggle="collapse"  data-target=".region1">
                                        <td colspan="53"><a class="detail-icon" href="javascript:"><i class="fa fa-desktop" aria-hidden="true"></i>&nbsp;Region1</a></td>
                                    </tr>
                                    <tr >
            <td colspan="6" class="hiddenRow">
                                     <div class="accordian-body collapse region1" > 
            
            <table class="table table-bordered ">
            <thead>
                            <tr class="bg-primary">
                                <th width="160"  rowspan="2">No.</th>
                                <th width="160"  rowspan="2">Last Update</th>
                                <th width="160"  rowspan="2">BV Station</th>
                                <th width="160"  rowspan="2">Route Code</th>
                                <th width="160"  rowspan="2">View</th>
                                    <th width="160" colspan="4">ม.ค.</th>
                                    <th width="160" colspan="4">ก.พ.</th>
                                    <th width="160" colspan="4">มี.ค.</th>
                                    <th width="160" colspan="4">เม.ย.</th>
                                    <th width="160" colspan="4">พ.ค.</th>
                                    <th width="160" colspan="4">มิ.ย.</th>
                                    <th width="160" colspan="4">ก.ค.</th>
                                    <th width="160" colspan="4">ส.ค.</th>
                                    <th width="160" colspan="4">ก.ย.</th>
                                    <th width="160" colspan="4">ต.ค.</th>
                                    <th width="160" colspan="4">พ.ย.</th>
                                    <th width="160" colspan="4">ธ.ค.</th>
                            </tr>
                            <tr class="bg-primary">
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                            </tr>
                        </thead>
                        <tbody>
             <tr  class=" first-row "  >
                                                    <td  style="padding: 8px 0px; text-align: center;" rowspan="3">1</td>
                                                    <td  style="padding: 8px 0px; text-align: center;" rowspan="3">
                                                        15/10/2017
                                                    </td>
                                                    <td  style="text-align: center;" rowspan="3">3" COTCO</td>
                                                    <td  style="text-align: center;" rowspan="3">RC40112</td>
                                                    <td  class="text-center" style="padding: 8px 0px; text-align: center;" rowspan="3">
                                                        <a href="InspectionDataView.aspx">View</a>
                                                    </td>

                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center" style="background-color: rgb(255, 255, 255);">
                                                                <a title="" style="color: black;" href="InspectionDataEdit.aspx" data-original-title='    <div class="text-left">Full soil to air inspection</div>&#10;    <div class="text-left">RC40112</div>&#10;    <div class="text-left">3" COTCO</div>&#10;    <div class="text-left">ปท.3 ปอก.</div>&#10;    <div class="text-left">Inspection Date: 20/03/2018</div>&#10;' data-toggle="tooltip" data-placement="top">
                                                                    FSA
                                                                </a>
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                </tr>
                                                  <tr class="hiddenRow ">
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center" style="background-color: rgb(255, 255, 255);">
                                                                <a title="" style="color: black;" href="/PipingInspection_test/Inspection/FullCorrosionUnderInsulation/2623" data-original-title='    <div class="text-left">Full corrosion under insulation inspection</div>&#10;    <div class="text-left">RC40112</div>&#10;    <div class="text-left">3" COTCO</div>&#10;    <div class="text-left">ปท.3 ปอก.</div>&#10;    <div class="text-left">Inspection Date: 20/03/2018</div>&#10;' data-toggle="tooltip" data-placement="top">
                                                                    FCUI
                                                                </a>
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                </tr>
                                                <tr class="hiddenRow ">
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center" style="background-color: rgb(255, 255, 255);">
                                                                <a title="" style="color: black;" href="/PipingInspection_test/Inspection/FullCorrosionUnderPipeSupport/2624" data-original-title='    <div class="text-left">Full corrosion under pipe support inspection</div>&#10;    <div class="text-left">RC40112</div>&#10;    <div class="text-left">3" COTCO</div>&#10;    <div class="text-left">ปท.3 ปอก.</div>&#10;    <div class="text-left">Inspection Date: 20/03/2018</div>&#10;' data-toggle="tooltip" data-placement="top">
                                                                    FCUS
                                                                </a>
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                </tr>
                                               <tr  class="first-row  " >
                                                    <td  style="padding: 8px 0px; text-align: center;" rowspan="3">1</td>
                                                    <td  style="padding: 8px 0px; text-align: center;" rowspan="3">
                                                        15/10/2017
                                                    </td>
                                                    <td  style="text-align: center;" rowspan="3">3" COTCO</td>
                                                    <td  style="text-align: center;" rowspan="3">RC40112</td>
                                                    <td  class="text-center" style="padding: 8px 0px; text-align: center;" rowspan="3">
                                                        <a href="InspectionDataView.aspx">View</a>
                                                    </td>

                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center" style="background-color: rgb(255, 255, 255);">
                                                                <a title="" style="color: black;" href="/PipingInspection_test/Inspection/FullSoilToAir/2622" data-original-title='    <div>Full soil to air inspection</div>&#10;    <div>RC40112</div>&#10;    <div>3" COTCO</div>&#10;    <div>ปท.3 ปอก.</div>&#10;    <div>Inspection Date: 20/03/2018</div>&#10;' data-toggle="tooltip" data-placement="top">
                                                                    FSA
                                                                </a>
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                </tr>
                                                <tr class=" ">
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                                <a title="" style="color: black;" href="/PipingInspection_test/Inspection/WallThickness/2680" data-original-title='<div class="text-left">Wall thickness inspecton</div><div class="text-left">Wall thickness inspecton</div><div class="text-left">Wall thickness inspecton</div>' data-toggle="tooltip" data-placement="top">
                                                                    WT
                                                                </a>
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                </tr>
                                                <tr class=" ">
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center" style="background-color: rgb(255, 255, 255);">
                                                                <a title="" style="color: black;" href="/PipingInspection_test/Inspection/SoilToAir/2681" data-original-title='    <div class="text-left">Soil to air inspection</div>&#10;    <div class="text-left">RC0460</div>&#10;    <div class="text-left">BV2.2</div>&#10;    <div class="text-left">ปท.3 ปอก.</div>&#10;    <div class="text-left">Inspection Date: 20/02/2018</div>&#10;' data-toggle="tooltip" data-placement="top">
                                                                    SA
                                                                </a>
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                </tr>

                                                </tbody>
            </table>
             </div>
              </td>
        </tr>
                                   <tr class="bg-success accordion-toggle" data-toggle="collapse"  data-target=".region2">
                                        <td colspan="53"><a class="detail-icon" href="javascript:"><i class="fa fa-desktop" aria-hidden="true"></i>&nbsp;Region2</a></td>
                                    </tr>

                                    <tr class="bg-success accordion-toggle" data-toggle="collapse"  data-target=".region3">
                                        <td colspan="53"><a class="detail-icon" href="javascript:"><i class="fa fa-desktop" aria-hidden="true"></i>&nbsp;Region3</a></td>
                                    </tr>

                                    <tr >
            <td colspan="53" class="hiddenRow">
             
            <div class="accordian-body collapse region3" id="region3"> 
                        <table class="table table-bordered table-responsive table-hover">
            <thead>
                            <tr class="bg-primary">
                                <th width="160"  rowspan="2">No.</th>
                                <th width="160"  rowspan="2">Last Update</th>
                                <th width="160"  rowspan="2">BV Station</th>
                                <th width="160"  rowspan="2">Route Code</th>
                                <th width="160"  rowspan="2">View</th>
                                    <th width="160" colspan="4">ม.ค.</th>
                                    <th width="160" colspan="4">ก.พ.</th>
                                    <th width="160" colspan="4">มี.ค.</th>
                                    <th width="160" colspan="4">เม.ย.</th>
                                    <th width="160" colspan="4">พ.ค.</th>
                                    <th width="160" colspan="4">มิ.ย.</th>
                                    <th width="160" colspan="4">ก.ค.</th>
                                    <th width="160" colspan="4">ส.ค.</th>
                                    <th width="160" colspan="4">ก.ย.</th>
                                    <th width="160" colspan="4">ต.ค.</th>
                                    <th width="160" colspan="4">พ.ย.</th>
                                    <th width="160" colspan="4">ธ.ค.</th>
                            </tr>
                            <tr class="bg-primary">
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                                    <td width="40">1</td>
                                    <td width="40">2</td>
                                    <td width="40">3</td>
                                    <td width="40">4</td>
                            </tr>
                        </thead></thead>
                      <tbody>
                      
                      <tr class="first-row">
                                                    <td width="60" style="padding: 8px 0px; text-align: center;" rowspan="6">3</td>
                                                    <td width="100" style="padding: 8px 0px; text-align: center;" rowspan="6">
                                                        15/10/2017
                                                    </td>
                                                    <td width="120" style="text-align: center;" rowspan="6">RA4</td>
                                                    <td width="120" style="text-align: center;" rowspan="6">RC4100</td>
                                                    <td width="60" class="text-center" style="padding: 8px 0px; text-align: center;" rowspan="6">
                                                        <a href="InspectionDataView.aspx">View</a>
                                                    </td>

                                                        <td class="month-td text-center" style="background-color: rgb(255, 0, 0);">
                                                                <a title="" style="color: black;" href="/PipingInspection_test/Inspection/CoatingCondition/2592" data-original-title="    <div class='text-left'>Coating condition inspection</div>&#10;    <div class='text-left'>RC4100</div>&#10;    <div class='text-left'>RA4</div>&#10;    <div class='text-left'>ปท.5 ปตก.</div>&#10;    <div class='text-left'>Inspection Date: 01/01/2018</div>&#10;" data-toggle="tooltip" data-placement="top">
                                                                    CT
                                                                </a>
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                        <td class="month-td text-center">
                                                        </td>
                                                </tr>
                      </tbody>
                      </table>
       
             </div>
            
            
             </td>
        </tr>

                                               
                                               
    </tbody>
</table>
                </div>
                </div>

     
          </div>
            <div class="card-footer small text-muted">Updated yesterday at 11:59 PM</div>
          </div>

</div>
   </div>




        </div>
          </div>
        
        </div>

     </div>
         
<!--- Content --->
</div> 
    </div>
    </div>

    <script>
        $('[data-toggle="tooltip"]').tooltip({ html: true });




      

            $('.region1').collapse('show');
           $('.region3').collapse('show');



   




      /*
        var $table = $('.table-fix'),
    $bodyCells = $table.find('thead tr:nth-child(2)').children(),
    colWidth;

       

      
        colWidth = $bodyCells.map(function () {
            return $(this).width();
        }).get();

       
        $table.find('tbody tr').children().each(function (i, v) {
            $(v).width(colWidth[i]);
        });    
        */
        </script>

</asp:Content>

