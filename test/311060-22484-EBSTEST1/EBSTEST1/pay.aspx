<%@ Page Language="vb" AutoEventWireup="false" Codebehind="pay.aspx.vb" Inherits="EBSTEST1.pay"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>E-Billing Solutions Pvt Ltd - Payment Page</TITLE>
		<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=iso-8859-1">
		<style> h1 { font-family:Arial,sans-serif; font-size:24pt; color:#08185A; font-weight:100; margin-bottom:0.1em}
	h2.co { font-family:Arial,sans-serif; font-size:24pt; color:#FFFFFF; margin-top:0.1em; margin-bottom:0.1em; font-weight:100}
	h3.co { font-family:Arial,sans-serif; font-size:16pt; color:#000000; margin-top:0.1em; margin-bottom:0.1em; font-weight:100}
	h3 { font-family:Arial,sans-serif; font-size:16pt; color:#08185A; margin-top:0.1em; margin-bottom:0.1em; font-weight:100}
	body { font-family:Verdana,Arial,sans-serif; font-size:11px; color:#08185A;}
	th { font-size:12px;background:#015289;color:#FFFFFF;font-weight:bold;height:30px;}
	td { font-size:12px;background:#DDE8F3}
	.pageTitle { font-size:24px;}
		</style>
		<script language="JavaScript">
function validate(){
	
	var frm = document.frmTransaction;
	var optFields = Array('description[delivery_address_2]','description[delivery_state]','description[delivery_telephone]','description[delivery_fax]', 'description[billing_address_2]','description[billing_state]', 'description[billing_telephone]','description[billing_fax]');
	var aName = Array();
	aName['account_id'] = 'Account ID';
	aName['reference_no'] = 'Reference No';
	aName['description'] = 'Description';
	aName['name'] = 'First Name';
	aName['name_2'] = 'Last Name';
	aName['address'] = 'Address 1';
	aName['city'] = 'City';
	aName['state'] = 'State';
	aName['postal_code'] = 'Post Code';
	aName['country'] = 'Country';
	aName['email'] = 'Email';

	for(var i = 0; i < frm.elements.length ; i++){
		
		if(!optFields.inArray(frm.elements[i].name)){
			if(frm.elements[i].value.length == 0){
				alert("Invalid input for " + aName[frm.elements[i].name]);
				frm.elements[i].focus();
				return false;
			}
			
			if(frm.elements[i].name == 'email]'){
				if(!validateEmail(frm.elements[i].value)){
					alert("Invalid input for " + aName[frm.elements[i].name]);
					frm.elements[i].focus();
					return false;
				}		
			}
			if(frm.elements[i].name == 'reference_no]'){
				var d = new Date();
				frm.elements[i].value = d.getTime();
			}
		}
	}  
	return true;
}
function validateEmail(email) {
    //Validating the email field
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
	//"
    if (! email.match(re)) {
        return (false);
    }
    return(true);
}


Array.prototype.inArray = function (value)
// Returns true if the passed value is found in the
// array.  Returns false if it is not.
{
    var i;
    for (i=0; i < this.length; i++) {
        // Matches identical (===), not just similar (==).
        if (this[i] === value) {
            return true;
        }
    }
    return false;
};


		</script>
	</HEAD>
	<BODY LEFTMARGIN="0" TOPMARGIN="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<center>
			<table width='100%' cellpadding='0' cellspacing="0">
				<tr>
					<th width='90%'>
						<h2 class='co'>&nbsp;EBS Payment Integration Page - Version 2</h2>
					</th>
				</tr>
			</table>
			<center><h1>PHP Example</h1>
			</center>
			<center><h3>Request Details</h3>
			</center>
			<form method="post" action="https://secure.ebs.in/pg/ma/sale/pay/" name="frmTransaction"
				id="frmTransaction" onSubmit="return validate()">
				<table width="600" cellpadding="2" cellspacing="2" border="0">
					<tr>
						<td class="fieldName" width="50%">Account Id</td>
						<td align="left" width="50%">
							<input name="account_id" type="text" value="7729"></td>
					</tr>
					<tr>
						<th colspan="2">
							Transaction Details</th>
					</tr>
					<tr>
						<td class="fieldName" width="50%">Reference No</td>
						<td align="left" width="50%">
							<input name="reference_no" type="text"></td>
					</tr>
					<tr>
						<td class="fieldName" width="50%">Sale Amount</td>
						<td align="left" width="50%">
							<input name="amount" type="text"> INR</td>
					</tr>
					<tr>
						<td class="fieldName" width="50%">Description</td>
						<td align="left" width="50%">
							<input name="description" type="text"></td>
					</tr>
					<tr>
						<th colspan="2">
							Billing Address</th>
					</tr>
					<tr>
						<td class="fieldName"><span class="error">*</span>
							Name</td>
						<td align="left">
							<input name="name" type="text"></td>
					</tr>
					<tr>
						<td class="fieldName"><span class="error">*</span>Address</td>
						<td align="left">
							<input name="address" type="text">
						</td>
					</tr>
					<tr>
						<td class="fieldName"><span class="error">*</span>City</td>
						<td align="left">
							<input name="city" type="text">
						</td>
					</tr>
					<tr>
						<td class="fieldName">State/Province</td>
						<td align="left">
							<input name="state" type="text">
						</td>
					</tr>
					<tr>
						<td class="fieldName"><span class="error">*</span>ZIP/Postal Code</td>
						<td align="left">
							<input name="postal_code" type="text">
						</td>
					</tr>
					<tr>
						<td class="fieldName"><span class="error">*</span>Country</td>
						<td align="left">
							<select name="country">
								<option value=""></option>
								<option value="ABW">Aruba</option>
								<option value="AFG">Afghanistan</option>
								<option value="AGO">Angola</option>
								<option value="AIA">Anguilla</option>
								<option value="ALA">�land Islands</option>
								<option value="ALB">Albania</option>
								<option value="AND">Andorra</option>
								<option value="ANT">Netherlands Antilles</option>
								<option value="ARE">United Arab Emirates</option>
								<option value="ARG">Argentina</option>
								<option value="ARM">Armenia</option>
								<option value="ASM">American Samoa</option>
								<option value="ATA">Antarctica</option>
								<option value="ATF">French Southern Territories</option>
								<option value="ATG">Antigua and Barbuda</option>
								<option value="AUS">Australia</option>
								<option value="AUT">Austria</option>
								<option value="AZE">Azerbaijan</option>
								<option value="BDI">Burundi</option>
								<option value="BEL">Belgium</option>
								<option value="BEN">Benin</option>
								<option value="BFA">Burkina Faso</option>
								<option value="BGD">Bangladesh</option>
								<option value="BGR">Bulgaria</option>
								<option value="BHR">Bahrain</option>
								<option value="BHS">Bahamas</option>
								<option value="BIH">Bosnia and Herzegovina</option>
								<option value="BLM">Saint Barth�lemy</option>
								<option value="BLR">Belarus</option>
								<option value="BLZ">Belize</option>
								<option value="BMU">Bermuda</option>
								<option value="BOL">Bolivia</option>
								<option value="BRA">Brazil</option>
								<option value="BRB">Barbados</option>
								<option value="BRN">Brunei Darussalam</option>
								<option value="BTN">Bhutan</option>
								<option value="BVT">Bouvet Island</option>
								<option value="BWA">Botswana</option>
								<option value="CAF">Central African Republic</option>
								<option value="CAN">Canada</option>
								<option value="CCK">Cocos (Keeling) Islands</option>
								<option value="CHE">Switzerland</option>
								<option value="CHL">Chile</option>
								<option value="CHN">China</option>
								<option value="CIV">C�te d`Ivoire</option>
								<option value="CMR">Cameroon</option>
								<option value="COD">Congo, the Democratic Republic of the</option>
								<option value="COG">Congo</option>
								<option value="COK">Cook Islands</option>
								<option value="COL">Colombia</option>
								<option value="COM">Comoros</option>
								<option value="CPV">Cape Verde</option>
								<option value="CRI">Costa Rica</option>
								<option value="CUB">Cuba</option>
								<option value="CXR">Christmas Island</option>
								<option value="CYM">Cayman Islands</option>
								<option value="CYP">Cyprus</option>
								<option value="CZE">Czech Republic</option>
								<option value="DEU">Germany</option>
								<option value="DJI">Djibouti</option>
								<option value="DMA">Dominica</option>
								<option value="DNK">Denmark</option>
								<option value="DOM">Dominican Republic</option>
								<option value="DZA">Algeria</option>
								<option value="ECU">Ecuador</option>
								<option value="EGY">Egypt</option>
								<option value="ERI">Eritrea</option>
								<option value="ESH">Western Sahara</option>
								<option value="ESP">Spain</option>
								<option value="EST">Estonia</option>
								<option value="ETH">Ethiopia</option>
								<option value="FIN">Finland</option>
								<option value="FJI">Fiji</option>
								<option value="FLK">Falkland Islands (Malvinas)</option>
								<option value="FRA">France</option>
								<option value="FRO">Faroe Islands</option>
								<option value="FSM">Micronesia, Federated States of</option>
								<option value="GAB">Gabon</option>
								<option value="GBR">United Kingdom</option>
								<option value="GEO">Georgia</option>
								<option value="GGY">Guernsey</option>
								<option value="GHA">Ghana</option>
								<option value="GI">N Guinea</option>
								<option value="GIB">Gibraltar</option>
								<option value="GLP">Guadeloupe</option>
								<option value="GMB">Gambia</option>
								<option value="GNB">Guinea-Bissau</option>
								<option value="GNQ">Equatorial Guinea</option>
								<option value="GRC">Greece</option>
								<option value="GRD">Grenada</option>
								<option value="GRL">Greenland</option>
								<option value="GTM">Guatemala</option>
								<option value="GUF">French Guiana</option>
								<option value="GUM">Guam</option>
								<option value="GUY">Guyana</option>
								<option value="HKG">Hong Kong</option>
								<option value="HMD">Heard Island and McDonald Islands</option>
								<option value="HND">Honduras</option>
								<option value="HRV">Croatia</option>
								<option value="HTI">Haiti</option>
								<option value="HUN">Hungary</option>
								<option value="IDN">Indonesia</option>
								<option value="IMN">Isle of Man</option>
								<option value="IND" selected>India</option>
								<option value="IOT">British Indian Ocean Territory</option>
								<option value="IRL">Ireland</option>
								<option value="IRN">Iran, Islamic Republic of</option>
								<option value="IRQ">Iraq</option>
								<option value="ISL">Iceland</option>
								<option value="ISR">Israel</option>
								<option value="ITA">Italy</option>
								<option value="JAM">Jamaica</option>
								<option value="JEY">Jersey</option>
								<option value="JOR">Jordan</option>
								<option value="JPN">Japan</option>
								<option value="KAZ">Kazakhstan</option>
								<option value="KEN">Kenya</option>
								<option value="KGZ">Kyrgyzstan</option>
								<option value="KHM">Cambodia</option>
								<option value="KIR">Kiribati</option>
								<option value="KNA">Saint Kitts and Nevis</option>
								<option value="KOR">Korea, Republic of</option>
								<option value="KWT">Kuwait</option>
								<option value="LAO">Lao People`s Democratic Republic</option>
								<option value="LBN">Lebanon</option>
								<option value="LBR">Liberia</option>
								<option value="LBY">Libyan Arab Jamahiriya</option>
								<option value="LCA">Saint Lucia</option>
								<option value="LIE">Liechtenstein</option>
								<option value="LKA">Sri Lanka</option>
								<option value="LSO">Lesotho</option>
								<option value="LTU">Lithuania</option>
								<option value="LUX">Luxembourg</option>
								<option value="LVA">Latvia</option>
								<option value="MAC">Macao</option>
								<option value="MAF">Saint Martin (French part)</option>
								<option value="MAR">Morocco</option>
								<option value="MCO">Monaco</option>
								<option value="MDA">Moldova</option>
								<option value="MDG">Madagascar</option>
								<option value="MDV">Maldives</option>
								<option value="MEX">Mexico</option>
								<option value="MHL">Marshall Islands</option>
								<option value="MKD">Macedonia, the former Yugoslav Republic of</option>
								<option value="MLI">Mali</option>
								<option value="MLT">Malta</option>
								<option value="MMR">Myanmar</option>
								<option value="MNE">Montenegro</option>
								<option value="MNG">Mongolia</option>
								<option value="MNP">Northern Mariana Islands</option>
								<option value="MOZ">Mozambique</option>
								<option value="MRT">Mauritania</option>
								<option value="MSR">Montserrat</option>
								<option value="MTQ">Martinique</option>
								<option value="MUS">Mauritius</option>
								<option value="MWI">Malawi</option>
								<option value="MYS">Malaysia</option>
								<option value="MYT">Mayotte</option>
								<option value="NAM">Namibia</option>
								<option value="NCL">New Caledonia</option>
								<option value="NER">Niger</option>
								<option value="NFK">Norfolk Island</option>
								<option value="NGA">Nigeria</option>
								<option value="NIC">Nicaragua</option>
								<option value="NO">R Norway</option>
								<option value="NIU">Niue</option>
								<option value="NLD">Netherlands</option>
								<option value="NPL">Nepal</option>
								<option value="NRU">Nauru</option>
								<option value="NZL">New Zealand</option>
								<option value="OMN">Oman</option>
								<option value="PAK">Pakistan</option>
								<option value="PAN">Panama</option>
								<option value="PCN">Pitcairn</option>
								<option value="PER">Peru</option>
								<option value="PHL">Philippines</option>
								<option value="PLW">Palau</option>
								<option value="PNG">Papua New Guinea</option>
								<option value="POL">Poland</option>
								<option value="PRI">Puerto Rico</option>
								<option value="PRK">Korea, Democratic People`s Republic of</option>
								<option value="PRT">Portugal</option>
								<option value="PRY">Paraguay</option>
								<option value="PSE">Palestinian Territory, Occupied</option>
								<option value="PYF">French Polynesia</option>
								<option value="QAT">Qatar</option>
								<option value="REU">R�union</option>
								<option value="ROU">Romania</option>
								<option value="RUS">Russian Federation</option>
								<option value="RWA">Rwanda</option>
								<option value="SAU">Saudi Arabia</option>
								<option value="SDN">Sudan</option>
								<option value="SEN">Senegal</option>
								<option value="SGP">Singapore</option>
								<option value="SGS">South Georgia and the South Sandwich Islands</option>
								<option value="SHN">Saint Helena</option>
								<option value="SJM">Svalbard and Jan Mayen</option>
								<option value="SLB">Solomon Islands</option>
								<option value="SLE">Sierra Leone</option>
								<option value="SLV">El Salvador</option>
								<option value="SMR">San Marino</option>
								<option value="SOM">Somalia</option>
								<option value="SPM">Saint Pierre and Miquelon</option>
								<option value="SRB">Serbia</option>
								<option value="STP">Sao Tome and Principe</option>
								<option value="SUR">Suriname</option>
								<option value="SVK">Slovakia</option>
								<option value="SVN">Slovenia</option>
								<option value="SWE">Sweden</option>
								<option value="SWZ">Swaziland</option>
								<option value="SYC">Seychelles</option>
								<option value="SYR">Syrian Arab Republic</option>
								<option value="TCA">Turks and Caicos Islands</option>
								<option value="TCD">Chad</option>
								<option value="TGO">Togo</option>
								<option value="THA">Thailand</option>
								<option value="TJK">Tajikistan</option>
								<option value="TKL">Tokelau</option>
								<option value="TKM">Turkmenistan</option>
								<option value="TLS">Timor-Leste</option>
								<option value="TON">Tonga</option>
								<option value="TTO">Trinidad and Tobago</option>
								<option value="TUN">Tunisia</option>
								<option value="TUR">Turkey</option>
								<option value="TUV">Tuvalu</option>
								<option value="TWN">Taiwan, Province of China</option>
								<option value="TZA">Tanzania, United Republic of</option>
								<option value="UGA">Uganda</option>
								<option value="UKR">Ukraine</option>
								<option value="UMI">United States Minor Outlying Islands</option>
								<option value="URY">Uruguay</option>
								<option value="USA">United States</option>
								<option value="UZB">Uzbekistan</option>
								<option value="VAT">Holy See (Vatican City State)</option>
								<option value="VCT">Saint Vincent and the Grenadines</option>
								<option value="VEN">Venezuela</option>
								<option value="VGB">Virgin Islands, British</option>
								<option value="VIR">Virgin Islands, U.S.</option>
								<option value="VNM">Viet Nam</option>
								<option value="VUT">Vanuatu</option>
								<option value="WLF">Wallis and Futuna</option>
								<option value="WSM">Samoa</option>
								<option value="YEM">Yemen</option>
								<option value="ZAF">South Africa</option>
								<option value="ZMB">Zambia</option>
								<option value="ZWE">Zimbabwe</option>
							</select>
						</td>
					</tr>
					<tr>
						<td class="fieldName"><span class="error">*</span>Email</td>
						<td align="left">
							<input name="email" type="text">
						</td>
					</tr>
					<tr>
						<td class="fieldName">Telephone</td>
						<td align="left"><input name="phone" type="text"></td>
					</tr>
					<tr>
						<td class="fieldName">Return Url</td>
						<td align="left"><input name="return_url" type="text" size="60">
						</td>
					</tr>
					<tr>
						<td class="fieldName">Mode</td>
						<td align="left"><select name="mode">
								<option value="TEST" selected>TEST</option>
								<option value="LIVE">LIVE</option>
							</select>
						</td>
					</tr>
					<tr>
						<td valign="top" align="center" colspan="2">
							<input name="submitted" value="Submit" type="submit" id="Submit1">&nbsp; <input value="Reset" type="reset">
						</td>
					</tr>
					<tr>
						<td valign="top" align="center" colspan="2">
							<span class="error">*</span>
							<span>denotes required field</span>
						</td>
					</tr>
				</table>
			</form>
		</center>
		<table width='100%' cellpadding='0' cellspacing="0">
			<tr>
				<th width='90%'>
					&nbsp;</th></tr>
		</table>
	</BODY>
</HTML>
