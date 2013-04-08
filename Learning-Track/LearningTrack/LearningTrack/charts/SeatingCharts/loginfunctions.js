function seatTaken(seatnumber, taken) //this function creates the JavaScript object
{
    //PROPERTIES LISTED HERE --------------------------
	this.seat=seatnumber; //1
	this.available=taken;

}
/*===============================================================================================================*/
function queryXML() //this function will query the appropriate XML file and return the array of JavaScript objects
{ //begin function
	var studArray = new Array(); //initiate the array for it to return
	if (window.XMLHttpRequest)
		{// code for IE7+, Firefox, Chrome, Opera, Safari
			xmlhttp=new XMLHttpRequest(); //create xml request
		}
	else
		{// code for IE6, IE5
			xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
		}
 
		xmlhttp.open("GET","login_xml.xml",false);
		xmlhttp.send();
		xmlDoc=xmlhttp.responseXML; 

		var x=xmlDoc.getElementsByTagName("SEAT");
		for (i=0;i<x.length;i++)
		{ 
			//constructor for the objects that represent whether a seat is taken
				studArray[i]=new seatTaken(
				x[i].getElementsByTagName("SEAT_NUMBER")[0].childNodes[0].nodeValue,
				x[i].getElementsByTagName("TAKEN")[0].childNodes[0].nodeValue);
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
//x.style.background="green";           //Change the style
//x.style.color="white";
//value = StudentArray.indexOf(id);
/*
	var pathArray = document.URL;
	var average_pre = pathArray.split('=');
	var average = average_pre[1];
	*/
	var index = getIndex(id, array);
	var seatnumber = studentSeatfromURL();

	if (array[index].available == "false")
	{
		x.style.background="#E42121";
		x.style.color="white";
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
	if (seatnumber != id)
	{
		document.write("<br>");
	}
	else
	{
		x=document.getElementById(id);  //Find the element 
		x.style.background="#E42121";
		document.write("You");
		
	}
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