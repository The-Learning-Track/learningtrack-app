function studentSeat(firstname,overallaverage,attendanceflag,missingassignmentFlag, seatnumber, homeworkavg, examavg, labavg, prediction) //this function creates the JavaScript object
{
    //PROPERTIES LISTED HERE --------------------------
	this.name=firstname; //1
	this.overallaverage=overallaverage; //2
	this.attendanceflag=attendanceflag; //3
	this.missingassignmentFlag=missingassignmentFlag; //4
	this.seat=seatnumber; //5
	this.homeworkAverage=homeworkavg; //6
	this.examAverage=examavg; //7
	this.labAverage=labavg; //8
    this.predictedGrade = prediction; //9
    
    //METHODS BEGIN HERE ------------------------------
	this.setHomework=setHomework;
	function setHomework(average)
	{	//set the homework average
		this.homeworkAverage=average;
	}
    
    this.setName=setName;
    function setName(setname)
    {
    	//can set the name
        this.name=name;
    }
    
    this.setAverage = setAverage;
    function setAverage(setAverage)
    {
    	this.overallaverage = setAverage;
    }
    
    this.setSeat = setSeat;
    function setSeat(setSeat)
    {
    	this.seat=setSeat;
    }
    
    this.setHWAverage = setHWAverage;
    function setHWAverage(setAverage)
    {
    	this.homeworkAverage = setAverage;
    }
    
    this.setexamAverage = setexamAverage;
    function setexamAverage(setexamAverage)
    {
    	this.examAverage=setexamAverage;
    }
    
    this.setLabAverage = setLabAverage;
    function setLabAverage(setLabAverage)
    {
    	this.labAverage = setLabAverage;
    }
    
    this.setGradePrediction = setGradePrediction;
    function setGradePrediction(setGradePrediction)
    {
    	this.predictedGrade = setGradePrediction;
    }
    
    this.addNote=addNote;
    function addNote(noteadd)
    {
    	//method to add a note
        this.note=noteadd;
    }
    
    this.getNote = getNote;
    function getNote()
    {
    	if (this.note != undefined)
        {
        	document.write(this.note);
        }
    }

}

/*===============================================================================================================*/

/*===============================================================================================================*/
function seatcolor(id, array) {
x=document.getElementById(id)  //Find the element 
//x.style.background="green";           //Change the style
//x.style.color="white";
//value = StudentArray.indexOf(id);
	var pathArray = document.URL;
	var average_pre = pathArray.split('=');
	var average = average_pre[1];
	var index = getIndex(id, array);
if (average == null){

	if (array[index].overallaverage == "bad")
	{
		x.style.background="#E42121";
		x.style.color="white";
	}
	else if (array[index].overallaverage=="ok")
	{
		x.style.background="#EAF11C";
		x.style.color="black";
	}
	else if (array[index].overallaverage=="good")
	{
		x.style.background="#006600";
		x.style.color="white";
	}
	else
	{
		x.style.background="#C8C8C8";
		x.style.color="null";
		}
}

else if (average == "homework")
{
if (array[index].homeworkAverage == "bad")
	{
		x.style.background="#E42121";
		x.style.color="white";
	}
	else if (array[index].homeworkAverage =="ok")
	{
		x.style.background="#EAF11C";
		x.style.color="black";
	}
	else if (array[index].homeworkAverage=="good")
	{
		x.style.background="#006600";
		x.style.color="white";
	}
	else
	{
		x.style.background="#C8C8C8";
		x.style.color="null";
	}

}
else if (average == "exam")
{
if (array[index].examAverage == "bad")
	{
		x.style.background="#E42121";
		x.style.color="white";
	}
	else if (array[index].examAverage =="ok")
	{
		x.style.background="#EAF11C";
		x.style.color="black";
	}
	else if (array[index].examAverage=="good")
	{
		x.style.background="#006600";
		x.style.color="white";
	}
	else
	{
		x.style.background="#C8C8C8";
		x.style.color="null";
		}

}
else if (average == "lab")
{
if (array[index].labAverage == "bad")
	{
		x.style.background="#E42121";
		x.style.color="white";
	}
	else if (array[index].labAverage=="ok")
	{
		x.style.background="#EAF11C";
		x.style.color="black";
	}
	else if (array[index].labAverage=="good")
	{
		x.style.background="#006600";
		x.style.color="white";
	}
	else
	{
		x.style.background="#C8C8C8";
		x.style.color="null";
		}

}

}//end of seat color function

//var test = K5.name;
/*===============================================================================================================*/

//create function that opens up the popup if the seat isn't empty
function seatPopup(id, array)
{
	var index=getIndex(id, array);
	if (index != null)
	{
	preurl = 'student_stats.html?id=';
	url = preurl + id;
	window.open(url,'popUpWindow','height=500,width=800,left=300,top=100,resizable=no,scrollbars=no,toolbar=no,menubar=no,location=0, directories=no, status=no');
	}


}

/*===============================================================================================================*/

function seatName(id, array)
{
	var index = getIndex(id, array);
	if (index != null)
	{
		document.write(array[index].name);
	}
	else
	{
		document.write("<br>");
	}
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
		
		//NOTE: EE68CBDF-B0CA-4C41-B100-FADF96CD1967 THE GUID CHANGES EVERY ITERATION OF A VERSION UPDATE (I.E. : 6.0 ->6.1)
		xmlhttp.open("GET","/private/var/mobile/Applications/EE68CBDF-B0CA-4C41-B100-FADF96CD1967/Documents/seatingChart.xml",false);
		xmlhttp.send();
		xmlDoc=xmlhttp.responseXML; 
		
		var x=xmlDoc.getElementsByTagName("SEAT");
		for (i=0;i<x.length;i++)
		{ 
			//constructor for the objects
				studArray[i]=new studentSeat(
				x[i].getElementsByTagName("NAME")[0].childNodes[0].nodeValue,
				x[i].getElementsByTagName("OVERALL_AVERAGE")[0].childNodes[0].nodeValue,
				x[i].getElementsByTagName("ATTENDANCE_FLAG")[0].childNodes[0].nodeValue,
				x[i].getElementsByTagName("MISSING_ASSIGNMENT_FLAG")[0].childNodes[0].nodeValue, 
				x[i].getElementsByTagName("SEAT_NUMBER")[0].childNodes[0].nodeValue,
				x[i].getElementsByTagName("HOMEWORK_AVERAGE")[0].childNodes[0].nodeValue,
				x[i].getElementsByTagName("EXAM_AVERAGE")[0].childNodes[0].nodeValue,
				x[i].getElementsByTagName("LAB_AVERAGE")[0].childNodes[0].nodeValue,
				x[i].getElementsByTagName("PREDICT_GRADE")[0].childNodes[0].nodeValue);
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
