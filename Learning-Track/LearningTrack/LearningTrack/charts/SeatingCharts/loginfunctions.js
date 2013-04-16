function getAppID(){
	var doc1 = document.URL;
	var new1 = doc1.split('/Applications/');
	var new2 = new1[1].split('/');
	return new2[0];	
}

function seatTaken(nme, num, studid, istake) //this function creates the JavaScript object
{
    //PROPERTIES LISTED HERE --------------------------
	this.name= nme; //1
	this.seatNum = num;
	this.studentID = studid;
	this.isStudent = istake;

}
/*===============================================================================================================*/
function queryXML() //this function will query the appropriate XML file and return the array of JavaScript objects
{ //begin function
	appID = getAppID();
	var studArray = new Array(); //initiate the array for it to return
	if (window.XMLHttpRequest)
		{// code for IE7+, Firefox, Chrome, Opera, Safari
			xmlhttp=new XMLHttpRequest(); //create xml request
		}
	else
		{// code for IE6, IE5
			xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
		}
 
		//xmlhttp.open("GET","login_xml.xml",false);
		var URL = '/private/var/mobile/Applications/' + appID + '/Documents/seatingChart.xml';
		xmlhttp.open("GET",URL,false);
		xmlhttp.send();
		xmlDoc=xmlhttp.responseXML; 

		var x=xmlDoc.getElementsByTagName("SEAT");
		for (i=0;i<x.length;i++)
		{ 
			//constructor for the objects that represent whether a seat is taken
				studArray[i]=new seatTaken(
				x[i].getElementsByTagName("NAME")[0].childNodes[0].nodeValue,
				x[i].getElementsByTagName("SEAT_NUMBER")[0].childNodes[0].nodeValue,
				x[i].getElementsByTagName("STUDENT_ID")[0].childNodes[0].nodeValue,
				x[i].getElementsByTagName("IS_CURRENT_STUDENT")[0].childNodes[0].nodeValue
				);
		}
		return studArray;
}//end function parenthesis

/*===============================================================================================================*/

function getIndex(id, array){ //function that returns the index of where a seat element object is
	for(i=0; i<array.length; i++) {
		if(array[i].seat == id)
		{
			return i;
			break;
		}
}
}//end of getIndex function

function getSeatIndex(id, array){ //function that finds whether a student is there
	for(i=0; i<array.length; i++) {
		if(array[i].seatNum == id)
		{
			return i;
			break;
		}
}
return null;
}//end of getIndex function

/*===============================================================================================================*/

//var id = studentSeatfromURL();
//student = getStudentObject(id);
function studentSeatfromURL()
{
//this function takes the path name which was generated when a seat was clicked
//and splits it to get the correct value of the seat number
	//var pathArray = window.location.pathname;
	var pathArray = document.URL;
	var studentSeat_pre = pathArray.split('=');
	var seatnumber = studentSeat_pre[1];
	//var studentSeatNumber = pathArray[1];
	return seatnumber;
}//end of function

/*===============================================================================================================*/
function seatTakenColor(id, array) {
x=document.getElementById(id);  //Find the element 
	var index = getSeatIndex(id, array);
	var seatnumber = studentSeatfromURL();
	var taken = currentStudentID(array);
	if (taken == id)
	{
		x.style.background="green";
	}
	else if (array[index].seatNum == id)
	{
		x.style.background="#E42121";
		x.style.color="white";
		//document.write("Taken");
	}
	else
	{
		x.style.background="#C8C8C8";
		x.style.color="null";
	}

}//end of seat color function
/*===============================================================================================================*/
function seatTakenName(id, array){
	var seatnumber = studentSeatfromURL();
	var taken = currentStudentID(studentsArray);
	var notEmpty = getSeatIndex(id, array);
	if (taken == id)
	{
		x=document.getElementById(id);  //Find the element 
		x.style.background="green";
		document.write("You");
	}
	else if (notEmpty != null)
	{
		document.write("Taken");
	}
	else
	{
		document.write("<br>");
	}
}
/*===============================================================================================================*/


function currentStudentID(array)
{
	for (i = 0; i < array.length; i++)
	{
		if (array[i].isStudent == 'true')
		{
			temp =  array[i].seatNum;
		}
	}
	return temp;
}

/*===============================================================================================================*/


function GetStudentID(array)
{
	for (i = 0; i < array.length; i++)
	{
		if (array[i].isStudent == 'true')
		{
			temp =  array[i].studentID;
		}
	}
	return temp;
}
/*===============================================================================================================*/

//create function that opens up the popup if the seat isn't empty
function takeSeat(id, array)
{

	//id = seatnumber 
	var seatnumber = studentSeatfromURL();
	i = getIndex(id, array);
	if (i == null)
	{
	preurl = 'morse_student.html?id=';
	url = preurl + id;
	window.location=url;
	//window.open(url,'popUpWindow','height=500,width=800,left=300,top=100,resizable=no,scrollbars=no,toolbar=no,menubar=no,location=0, directories=no, status=no');
	}


}
/*===============================================================================================================*/

//create function that opens up the popup if the seat isn't empty
function takeStudioSeat(id, array)
{
	var seatnumber = studentSeatfromURL();
	i = getIndex(id, array);
	if (i == null)
	{
	preurl = 'studio_student.html?id=';
	url = preurl + id;
	window.location = url;
	//window.open(url,'popUpWindow','height=500,width=800,left=300,top=100,resizable=no,scrollbars=no,toolbar=no,menubar=no,location=0, directories=no, status=no');
	}
	


}
