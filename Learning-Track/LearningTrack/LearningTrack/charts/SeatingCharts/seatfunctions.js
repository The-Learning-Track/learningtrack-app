function grade(gID, subject, assignname, score, points, studID) //this function creates the JavaScript object
{
    //PROPERTIES LISTED HERE --------------------------
        this.gradeID = gID;
        this.category = subject;
        this.assignmentName = assignname;
        this.grade = score;
        this.totalPoints=points;
        this.studentID=studID;

    //METHODS BEGIN HERE ------------------------------
}
/*===============================================================================================================*/
/*
function GetGrades() //this function will query the appropriate XML file and return the array of JavaScript objects
{ //begin function
	//alert('hello!');
        var studArray = new Array(); //initiate the array for it to return
        if (window.XMLHttpRequest)
                {// code for IE7+, Firefox, Chrome, Opera, Safari
                        xmlhttp=new XMLHttpRequest(); //create xml request
                }
        else
                {// code for IE6, IE5
                        xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
                }
						//45630D06-579B-4141-8D13-08087F6A8936 IS SIMULATOR
 			xmlhttp.open("GET","/private/var/mobile/Applications/EE68CBDF-B0CA-4C41-B100-FADF96CD1967/Documents/courseGrades.xml",false);
 			//xmlhttp.open("GET","/private/var/mobile/Applications/45630D06-579B-4141-8D13-08087F6A8936/Documents/courseGrades.xml",false);
			//xmlhttp.open("GET","courseGrades.xml",false);
               // xmlhttp.open("GET","highcharts/courseGrades.xml",false);
                xmlhttp.send();
                xmlDoc=xmlhttp.responseXML;
                var x=xmlDoc.getElementsByTagName("Grade");
                //var y=xmlDoc.getElementsByTagName("seatLocation")[1].childNodes[0].nodeValue;
                for (i=0;i<x.length;i++)
                {
                        //constructor for the objects that represent whether a seat is taken
                                studArray[i]=new grade(
                                x[i].getElementsByTagName("ID")[0].childNodes[0].nodeValue,
                                x[i].getElementsByTagName("category")[0].childNodes[0].nodeValue,
                                x[i].getElementsByTagName("assignmentName")[0].childNodes[0].nodeValue,
                                x[i].getElementsByTagName("score")[0].childNodes[0].nodeValue,
                                x[i].getElementsByTagName("totalPoints")[0].childNodes[0].nodeValue,
                                x[i].getElementsByTagName("studentID")[0].childNodes[0].nodeValue
                                );

                }

                        //alert("Grade 1: " + studArray[0].grade + " Student ID: " + studArray[0].studentID);

        return studArray;
                //alert(y);

}//end function parenthesis
*/
/*===============================================================================================================*/
function calculateAverage(array)
{
        var sum = 0;
        var average;
        for (i = 0; i < array.length; i++)
        {
                sum = sum + array[i];
        }
        average = sum / array.length;
        return average;
}

/*===============================================================================================================*/

function standardDev(array)
{
        var average = calculateAverage(array);
        var squares = new Array()
        for (i = 0; i < array.length; i++)
        {
                var temp = average - array[i];
                var pow = Math.pow(temp, 2);
                squares.push(pow);
        }
        var mean = calculateAverage(squares);
        var squareroot = Math.sqrt(mean);
        return squareroot;
}

/*===============================================================================================================*/

function studentSeat(firstname, seatnumber, id) //this function creates the JavaScript object
{
	//alert('Getting to studentSeat: ' + firstname);
    //PROPERTIES LISTED HERE --------------------------
        this.name=firstname; //1
        this.seat=seatnumber; //5
    	this.studentID = id; //10
    	//if (id != undefined)
    	//{
    	//	alert('student seat object: ' + id);
    	//}

}

/*===============================================================================================================*/

/*===============================================================================================================*/
function seatcolor(id, array) {
//alert ('in seat color');
x=document.getElementById(id)  //Find the element

        var pathArray = document.URL;
        var average_pre = pathArray.split('=');
        var average = average_pre[1];
        var index = getIndex(id, array);
       // if (index != undefined)
        //{
        //	alert(index);
        //}
        //alert(index);
        //alert('gets here! ');
        grades = GetGrades();
        //alert('this will show it gets here after the grades xml');
        //alert('gets here: ' + grades);
        var student_id=array[index].studentID;
       //if (student_id != undefined)
       //{
        //	alert(student_id);
        //}
        //alert(studentid);
        var studHWgrades = new Array();
        var classHWgrades = new Array();
        var studLabgrades = new Array();
        var classLabgrades = new Array();
        var studExamgrades = new Array();
        var classExamgrades = new Array();
        var classAllgrades = new Array();
        var studAllgrades = new Array();
        for (i = 0; i < grades.length; i++)
        {
                //alert('loop id: ' + grades[i].studentID + 'student id: ' + student_id);
                if (grades[i].category == 'Homework')
                {
                        classHWgrades.push(parseFloat(grades[i].grade));
                }
                if ((grades[i].category == 'Homework') && (grades[i].studentID == student_id ))
                {
                        studHWgrades.push(parseFloat(grades[i].grade));
                }
                if (grades[i].category == 'Exam')
                {
                        classExamgrades.push(parseFloat(grades[i].grade));
                }
                if ((grades[i].category == 'Exam') && (grades[i].studentID == student_id ))
                {
                        studExamgrades.push(parseFloat(grades[i].grade));
                }
                if (grades[i].category == 'Lab')
                {
                        classLabgrades.push(parseFloat(grades[i].grade));
                }
                if ((grades[i].category == 'Lab') && (grades[i].studentID == student_id ))
                {
                        studLabgrades.push(parseFloat(grades[i].grade));
                }
                if (grades[i].studentID == student_id)
                {
                        studAllgrades.push(parseFloat(grades[i].grade));
                }
                classAllgrades.push(parseFloat(grades[i].grade));
        }

/* CALCULATE ALL AVERAGES */
        var studHWavg = calculateAverage(studHWgrades);
        var studLabavg = calculateAverage(studLabgrades);
        var studExamavg = calculateAverage(studExamgrades);
        var studOverallavg = calculateAverage(studAllgrades);
        //alert(studOverallavg);

        var classHWavg = calculateAverage(classHWgrades);
        var classExamavg = calculateAverage(classExamgrades);
        var classLabgavg = calculateAverage(classLabgrades);
        var classoverallavg = calculateAverage(classAllgrades);

        var HWstd = standardDev(classHWgrades);
        var Examstd = standardDev(classExamgrades);
        var Labstd = standardDev(classLabgrades);
        var Overallstd = standardDev(classAllgrades);

        var upboundHW = classHWavg + HWstd;
        var lowboundHW = classHWavg - HWstd;
        var upboundExam = classExamavg + Examstd;
        var lowboundExam = classExamavg - Examstd;
        var upboundLab = classLabgavg + Labstd;
        var lowboundLab = classLabgavg - Labstd;
        var upboundOverall = classoverallavg + Overallstd;
        var lowboundOverall = classoverallavg - Overallstd;

        //alert('Upper bound ' + upboundLab + ' lower bound: ' + lowboundLab + ' student average ' + studLabavg);

if (average == null)
{
        if ((studOverallavg < classoverallavg) && (studOverallavg > lowboundOverall)) //below average, above lowerbound
        {
                //should be an orangish color
                //x.style.background="#E42121";
                x.style.background="#FF9900";
                x.style.color="white";
        }
        else if ((studOverallavg > classoverallavg) && (studOverallavg < upboundOverall)) //above average, below upperbound
        {
                //should be yellowish green color
                //x.style.background="#006600";
                x.style.background="#33CC00";
                x.style.color="white";
        }
        else if (studOverallavg > upboundOverall) //above the upperbound
        {
                x.style.background="#336600";
                x.style.color="white";
        }
        else if (studOverallavg < lowboundOverall)  //below lowerbound
        {
                x.style.background="#FF3300";
                x.style.color="white";
        }
        else //default to gray if there's an issue
        {
                x.style.background="black";
                x.style.color="null";
        }
}

else if (average == "homework")
{
        if ((studHWavg < classHWavg) && (studHWavg > lowboundHW)) //below average, above lowerbound
        {
                x.style.background="#FF9900";
                x.style.color="white";
        }
        else if ((studHWavg > classHWavg) && (studHWavg < upboundHW)) //above average, below upperbound
        {
                x.style.background="#33CC00";
                x.style.color="white";
        }
        else if (studHWavg > upboundHW) //above the upperbound
        {
                x.style.background="#336600";
                x.style.color="white";
        }
        else if (studHWavg < lowboundHW) //below the lowerbound
        {
                x.style.background="#FF3300";
                x.style.color="white";
        }
        else
        {
                x.style.background="blue";
                x.style.color="null";
        }

}
else if (average == "exam")
{
        if ((studExamavg < classExamavg) && (studExamavg > lowboundExam)) //below average, above lowerbound
        {
                x.style.background="#FF9900";
                x.style.color="white";
        }
        else if ((studExamavg > classExamavg) && (studExamavg < upboundExam)) //above average, below upperbound
        {
                x.style.background="#33CC00";
                x.style.color="white";
        }
        else if (studExamavg > upboundExam) //above the upperbound
        {
                x.style.background="#336600";
                x.style.color="white";
        }
        else if (studExamavg < lowboundExam) //below the lowerbound
        {
                x.style.background="#FF3300";
                x.style.color="white";
        }
        else
        {
                x.style.background="white";
                x.style.color="null";
        }

}
else if (average == "lab")
{
        if ((studLabavg < classLabgavg)&&(studLabavg> lowboundLab))//below average, above lowerbound
        {
                x.style.background="#FF9900";
                x.style.color="white";
        }
        else if ((studLabavg > classLabgavg)&&(studLabavg< upboundLab)) //above average, below upperbound
        {
                x.style.background="#33CC00";
                x.style.color="white";
        }
        else if (studLabavg > upboundLab ) //above the upperbound
        {
                x.style.background="#336600";
                x.style.color="black";
        }
        else if (studLabavg < lowboundLab)
        {
                x.style.background = "#FF3300";
                x.style.color = "white";
        }
        else
        {
                x.style.background="pink";
                x.style.color="null";
        }

}
else
{
                x.style.background="#C8C8C8";
                x.style.color="null";
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
        preurl = 'highcharts/standardDev.htm?id='
        //preurl = 'student_stats.html?id=';
        url = preurl + id;
        //window.open(url,'popUpWindow','height=1000,width=980,resizable=no,scrollbars=no,toolbar=no,menubar=no,location=0, directories=no, status=no');
        window.location.href = url;
        //window.open(url);
        }
        //window.location.href = url;
        //var e = document.getElementByI


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


function isTaken(id, array)
{
        var index = getIndex(id, array);
        if (index != null)
        {
                return true;
        }
        else
        {
                return false;
        }
}

/*===============================================================================================================*/

function queryXML() //this function will query the appropriate XML file and return the array of JavaScript objects
{ //begin function
        //alert('gets here');
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
		//45630D06-579B-4141-8D13-08087F6A8936 IS SIMULATOR
		//xmlhttp.open("GET","/private/var/mobile/Applications/EE68CBDF-B0CA-4C41-B100-FADF96CD1967/Documents/seatingChart.xml",false);
		xmlhttp.open("GET","/private/var/mobile/Applications/EE68CBDF-B0CA-4C41-B100-FADF96CD1967/Documents/seatingChart.xml",false);
		//xmlhttp.open("GET","/private/var/mobile/Applications/45630D06-579B-4141-8D13-08087F6A8936/Documents/seatingChart.xml",false);
		
		//xmlhttp.open("GET","seatingChart.xml",false);
                xmlhttp.send();
                xmlDoc=xmlhttp.responseXML;

                var x=xmlDoc.getElementsByTagName("SEAT");
                for (i=0;i<x.length;i++)
                {
                        //constructor for the objects
                                studArray[i]=new studentSeat(
                                x[i].getElementsByTagName("NAME")[0].childNodes[0].nodeValue,
                                x[i].getElementsByTagName("SEAT_NUMBER")[0].childNodes[0].nodeValue,
                                x[i].getElementsByTagName("STUDENT_ID")[0].childNodes[0].nodeValue
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
function checkboxSubmit(studentsArray)
{
        //alert(studentsArray[0].studentID);
        var checked_array = new Array();
        var string = "?group="
        var chkbx = document.getElementsByName("group");
        var category = document.getElementsByName("category");
        for (i = 0; i < chkbx.length; i++) //loop through --> THIS WILL IGNORE EMPTY SEATS
        {
                if (chkbx[i].checked == true) //if a student seat is selected
                {
                        temp = chkbx[i].value; //take the seat number and make it into a temporary variable
                        for (j = 0; j < studentsArray.length; j++) //go through each of the students in the Array of students in the classroom
                        {
                                if(temp == studentsArray[j].seat) //if that temporary variable is equal to a student's seat
                                {
                                        string += studentsArray[j].studentID + ","; //adds the student id numbers to the URL
                                }
                        }
                }
        }
        //alert(string);
        preurl = 'highcharts/standardDevGroup.htm'
        url = preurl + string;
        //document.URL = url;
        window.location.href = url;
        //var e = document.getElementById("category");
        //var strUser = e.options[e.selectedIndex].value;
        //alert(strUser);

        //alert(category.selected.value);
}

/*===============================================================================================================*/


