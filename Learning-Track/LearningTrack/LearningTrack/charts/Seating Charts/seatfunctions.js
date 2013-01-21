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
A1=new studentSeat("Johnny","bad","false","false", "A1", "good", "ok", "bad", "A");
A2=new studentSeat("Jimmy","good","false","false", "A2",  "good", "ok", "bad", "B");
A3=new studentSeat("NULL","NULL","false","false", "A3",  "NULL", "NULL", "NULL", "C");
A4=new studentSeat("Johnny","bad","false","false", "A4",  "good", "ok", "bad", "A");
A5=new studentSeat("Jimmy","good","false","false", "A5",  "good", "ok", "bad", "B");
A6=new studentSeat("NULL","NULL","false","false", "A6",  "NULL", "NULL", "NULL", "C");
A7=new studentSeat("Johnny","bad","false","false", "A7",  "good", "ok", "bad", "D");
A8=new studentSeat("Jimmy","good","false","false", "A8",  "good", "ok", "bad", "A");
A9=new studentSeat("Jilly","ok","false","false", "A9",  "good", "ok", "bad", "B");
A10=new studentSeat("Johnny","bad","false","false", "A10",  "good", "ok", "bad", "A");
A11=new studentSeat("Jimmy","good","false","false", "A11",  "good", "ok", "bad", "B");
A12=new studentSeat("NULL","NULL","false","false", "A12",  "NULL", "NULL", "NULL", "A");
A13=new studentSeat("Johnny","bad","false","false", "A13",  "good", "ok", "bad", "A");
A14=new studentSeat("Jimmy","good","false","false", "A14",  "good", "ok", "bad", "A");

B1=new studentSeat("Johnny","bad","false","false", "B1",  "good", "ok", "bad", "A");
B2=new studentSeat("Jimmy","good","false","false", "B2",  "good", "ok", "bad", "A");
B3=new studentSeat("Jilly","ok","false","false", "B3",  "good", "ok", "bad", "A");
B4=new studentSeat("Johnny","bad","false","false", "B4",  "good", "ok", "bad", "A");
B5=new studentSeat("Jimmy","good","false","false", "B5",  "good", "ok", "bad", "A");
B6=new studentSeat("Jilly","ok","false","false", "B6",  "good", "ok", "bad", "A");
B7=new studentSeat("Johnny","bad","false","false", "B7",  "good", "ok", "bad", "A");
B8=new studentSeat("Jimmy","good","false","false", "B8",  "good", "ok", "bad", "A");
B9=new studentSeat("Jilly","ok","false","false", "B9",  "good", "ok", "bad", "A");
B10=new studentSeat("Johnny","bad","false","false", "B10",  "good", "ok", "bad", "A");
B11=new studentSeat("Jimmy","good","false","false", "B11",  "good", "ok", "bad", "A");
B12=new studentSeat("Jilly","ok","false","false", "B12",  "good", "ok", "bad", "A");
B13=new studentSeat("NULL","NULL","false","false", "B13",  "NULL", "NULL", "NULL", "A");
B14=new studentSeat("NULL","NULL","false","false", "B14",  "NULL", "NULL", "NULL", "A");

C1=new studentSeat("Johnny","bad","false","false", "C1",  "good", "ok", "bad", "A");
C2=new studentSeat("Jimmy","good","false","false", "C2",  "good", "ok", "bad", "A");
C3=new studentSeat("Jilly","ok","false","false", "C3",  "good", "ok", "bad", "A");
C4=new studentSeat("Johnny","bad","false","false", "C4",  "good", "ok", "bad", "A");
C5=new studentSeat("Jimmy","good","false","false", "C5",  "good", "ok", "bad", "A");
C6=new studentSeat("Jilly","ok","false","false", "C6",  "good", "ok", "bad", "A");
C7=new studentSeat("Johnny","bad","false","false", "C7",  "good", "ok", "bad", "A");
C8=new studentSeat("Jimmy","good","false","false", "C8",  "good", "ok", "bad", "A");
C9=new studentSeat("Jilly","ok","false","false", "C9",  "good", "ok", "bad", "A");
C10=new studentSeat("Johnny","bad","false","false", "C10",  "good", "ok", "bad", "A");
C11=new studentSeat("Jimmy","good","false","false", "C11",  "good", "ok", "bad", "A");
C12=new studentSeat("Jilly","ok","false","false", "C12",  "good", "ok", "bad", "A");
C13=new studentSeat("Johnny","bad","false","false", "C13",  "good", "ok", "bad", "A");
C14=new studentSeat("NULL","NULL","false","false", "C14",  "NULL", "NULL", "NULL", "A");

D1=new studentSeat("Johnny","bad","false","false", "D1",  "good", "ok", "bad", "A");
D2=new studentSeat("Jimmy","good","false","false", "D2",  "good", "ok", "bad", "A");
D3=new studentSeat("Jilly","ok","false","false", "D3",  "good", "ok", "bad", "A");
D4=new studentSeat("Johnny","bad","false","false", "D4",  "good", "ok", "bad", "A");
D5=new studentSeat("Jimmy","good","false","false", "D5",  "good", "ok", "bad", "A");
D6=new studentSeat("Jilly","ok","false","false", "D6",  "good", "ok", "bad", "A");
D7=new studentSeat("Johnny","bad","false","false", "D7",  "good", "ok", "bad", "A");
D8=new studentSeat("Jimmy","good","false","false", "D8",  "good", "ok", "bad", "A");
D9=new studentSeat("Jilly","ok","false","false", "D9",  "good", "ok", "bad", "A");
D10=new studentSeat("NULL","NULL","false","false", "D10",  "NULL", "NULL", "NULL", "A");
D11=new studentSeat("Jimmy","good","false","false", "D11",  "good", "ok", "bad", "A");
D12=new studentSeat("Jilly","ok","false","false", "D12",  "good", "ok", "bad", "A");
D13=new studentSeat("Johnny","bad","false","false", "D13",  "good", "ok", "bad", "A");
D14=new studentSeat("Jimmy","good","false","false", "D14",  "good", "ok", "bad", "A");

E1=new studentSeat("NULL","NULL","false","false", "E1",  "NULL", "NULL", "NULL", "A");
E2=new studentSeat("Jimmy","good","false","false", "E2",  "good", "ok", "bad", "A");
E3=new studentSeat("Jilly","ok","false","false", "E3",  "good", "ok", "bad", "A");
E4=new studentSeat("Johnny","bad","false","false", "E4",  "good", "ok", "bad", "A");
E5=new studentSeat("Jimmy","good","false","false", "E5",  "good", "ok", "bad", "A");
E6=new studentSeat("Jilly","ok","false","false", "E6",  "good", "ok", "bad", "A");
E7=new studentSeat("Johnny","bad","false","false", "E7",  "good", "ok", "bad", "A");
E8=new studentSeat("NULL","NULL","false","false", "E8",  "NULL", "NULL", "NULL", "A");
E9=new studentSeat("Jilly","ok","false","false", "E9",  "good", "ok", "bad", "A");
E10=new studentSeat("Johnny","bad","false","false", "E10",  "good", "ok", "bad", "A");
E11=new studentSeat("Jimmy","good","false","false", "E11",  "good", "ok", "bad", "A");
E12=new studentSeat("Jilly","ok","false","false", "E12",  "good", "ok", "bad", "A");
E13=new studentSeat("Johnny","bad","false","false", "E13",  "good", "ok", "bad", "A");
E14=new studentSeat("Jimmy","good","false","false", "E14",  "good", "ok", "bad", "A");

F1=new studentSeat("Johnny","bad","false","false", "F1",  "good", "ok", "bad", "A");
F2=new studentSeat("Jimmy","good","false","false", "F2",  "good", "ok", "bad", "A");
F3=new studentSeat("Jilly","ok","false","false", "F3",  "good", "ok", "bad", "A");
F4=new studentSeat("Johnny","bad","false","false", "F4",  "good", "ok", "bad", "A");
F5=new studentSeat("Jimmy","good","false","false", "F5",  "good", "ok", "bad", "A");
F6=new studentSeat("Jilly","ok","false","false", "F6",  "good", "ok", "bad", "A");
F7=new studentSeat("Johnny","bad","false","false", "F7",  "good", "ok", "bad", "A");
F8=new studentSeat("Jimmy","good","false","false", "F8",  "good", "ok", "bad", "A");
F9=new studentSeat("Jilly","ok","false","false", "F9",  "good", "ok", "bad", "A");
F10=new studentSeat("Johnny","bad","false","false", "F10",  "good", "ok", "bad", "A");
F11=new studentSeat("Jimmy","good","false","false", "F11",  "good", "ok", "bad", "A");
F12=new studentSeat("Jilly","ok","false","false", "F12",  "good", "ok", "bad", "A");
F13=new studentSeat("Johnny","bad","false","false", "F13",  "good", "ok", "bad", "A");
F14=new studentSeat("Jimmy","good","false","false", "F14",  "good", "ok", "bad", "A");

G1=new studentSeat("Johnny","bad","false","false", "G1",  "good", "ok", "bad", "A");
G2=new studentSeat("Jimmy","good","false","false", "G2",  "good", "ok", "bad", "A");
G3=new studentSeat("Jilly","ok","false","false", "G3",  "good", "ok", "bad", "A");
G4=new studentSeat("Johnny","bad","false","false", "G4",  "good", "ok", "bad", "A");
G5=new studentSeat("Jimmy","good","false","false", "G5",  "good", "ok", "bad", "A");
G6=new studentSeat("Jilly","ok","false","false", "G6",  "good", "ok", "bad", "A");
G7=new studentSeat("Johnny","bad","false","false", "G7",  "good", "ok", "bad", "A");
G8=new studentSeat("Jimmy","good","false","false", "G8",  "good", "ok", "bad", "A");
G9=new studentSeat("Jilly","ok","false","false", "G9",  "good", "ok", "bad", "A");
G10=new studentSeat("Johnny","bad","false","false", "G10",  "good", "ok", "bad", "A");
G11=new studentSeat("Jimmy","good","false","false", "G11",  "good", "ok", "bad", "A");
G12=new studentSeat("Jilly","ok","false","false", "G12",  "good", "ok", "bad", "A");
G13=new studentSeat("Johnny","bad","false","false", "G13",  "good", "ok", "bad", "A");
G14=new studentSeat("Jimmy","good","false","false", "G14",  "good", "ok", "bad", "A");

H1=new studentSeat("Johnny","bad","false","false", "H1",  "good", "ok", "bad", "A");
H2=new studentSeat("Jimmy","good","false","false", "H2",  "good", "ok", "bad", "A");
H3=new studentSeat("Jilly","ok","false","false", "H3",  "good", "ok", "bad", "A");
H4=new studentSeat("Johnny","bad","false","false", "H4",  "good", "ok", "bad", "A");
H5=new studentSeat("Jimmy","good","false","false", "H5",  "good", "ok", "bad", "A");
H6=new studentSeat("Jilly","ok","false","false", "H6",  "good", "ok", "bad", "A");
H7=new studentSeat("Johnny","bad","false","false", "H7",  "good", "ok", "bad", "A");
H8=new studentSeat("Jimmy","good","false","false", "H8",  "good", "ok", "bad", "A");
H9=new studentSeat("Jilly","ok","false","false", "H9",  "good", "ok", "bad", "A");
H10=new studentSeat("Johnny","bad","false","false", "H10",  "good", "ok", "bad", "A");
H11=new studentSeat("Jimmy","good","false","false", "H11",  "good", "ok", "bad", "A");
H12=new studentSeat("Jilly","ok","false","false", "H12",  "good", "ok", "bad", "A");
H13=new studentSeat("Johnny","bad","false","false", "H13",  "good", "ok", "bad", "A");
H14=new studentSeat("Jimmy","good","false","false", "H14",  "good", "ok", "bad", "A");

I1=new studentSeat("NULL","NULL","false","false", "I1",  "NULL", "NULL", "NULL", "A");
I2=new studentSeat("Jimmy","good","false","false", "I2",  "good", "ok", "bad", "A");
I3=new studentSeat("Jilly","ok","false","false", "I3",  "good", "ok", "bad", "A");
I4=new studentSeat("Johnny","bad","false","false", "I4",  "good", "ok", "bad", "A");
I5=new studentSeat("Jimmy","good","false","false", "I5",  "good", "ok", "bad", "A");
I6=new studentSeat("NULL","NULL","false","false", "I6",  "NULL", "NULL", "NULL", "A");
I7=new studentSeat("Johnny","bad","false","false", "I7",  "good", "ok", "bad", "A");
I8=new studentSeat("Jimmy","good","false","false", "I8",  "good", "ok", "bad", "A");
I9=new studentSeat("Jilly","ok","false","false", "I9",  "good", "ok", "bad", "A");
I10=new studentSeat("Johnny","bad","false","false", "I10",  "good", "ok", "bad", "A");
I11=new studentSeat("Jimmy","good","false","false", "I11",  "good", "ok", "bad", "A");
I12=new studentSeat("Jilly","ok","false","false", "I12",  "good", "ok", "bad", "A");
I13=new studentSeat("Johnny","bad","false","false", "I13",  "good", "ok", "bad", "A");
I14=new studentSeat("Jimmy","good","false","false", "I14",  "good", "ok", "bad", "A");

J1=new studentSeat("Johnny","bad","false","false", "J1",  "good", "ok", "bad", "A");
J2=new studentSeat("Jimmy","good","false","false", "J2",  "good", "ok", "bad", "A");
J3=new studentSeat("Jilly","ok","false","false", "J3",  "good", "ok", "bad", "A");
J4=new studentSeat("Johnny","bad","false","false", "J4",  "good", "ok", "bad", "A");
J5=new studentSeat("NULL","NULL","false","false", "J5",  "NULL", "NULL", "NULL", "A");
J6=new studentSeat("Jilly","ok","false","false", "J6",  "good", "ok", "bad", "A");
J7=new studentSeat("Johnny","bad","false","false", "J7",  "good", "ok", "bad", "A");
J8=new studentSeat("Jimmy","good","false","false", "J8",  "good", "ok", "bad", "A");
J9=new studentSeat("Jilly","ok","false","false", "J9",  "good", "ok", "bad", "A");
J10=new studentSeat("Johnny","bad","false","false", "J10",  "good", "ok", "bad", "A");
J11=new studentSeat("Jimmy","good","false","false", "J11",  "good", "ok", "bad", "A");
J12=new studentSeat("Jilly","ok","false","false", "J12",  "good", "ok", "bad", "A");
J13=new studentSeat("Johnny","bad","false","false", "J13",  "good", "ok", "bad", "A");
J14=new studentSeat("Jimmy","good","false","false", "J14",  "good", "ok", "bad", "A");

K1=new studentSeat("Johnny","bad","false","false", "K1",  "good", "ok", "bad", "A");
K2=new studentSeat("Jimmy","good","false","false", "K2",  "good", "ok", "bad", "A");
K3=new studentSeat("Jilly","ok","false","false", "K3",  "good", "ok", "bad", "A");
K4=new studentSeat("Johnny","bad","false","false", "K4",  "good", "ok", "bad", "A");
K5=new studentSeat("Jimmy","good","false","false", "K5",  "good", "ok", "bad", "A");
K6=new studentSeat("Jilly","ok","false","false", "K6",  "good", "ok", "bad", "A");
K7=new studentSeat("Johnny","bad","false","false", "K7",  "good", "ok", "bad", "A");
K8=new studentSeat("NULL","NULL","false","false", "K8",  "NULL", "NULL", "NULL", "A");
K9=new studentSeat("NULL","NULL","false","false", "K9",  "NULL", "NULL", "NULL", "A");
K10=new studentSeat("Johnny","bad","false","false", "K10",  "good", "ok", "bad", "A");
K11=new studentSeat("Jimmy","good","false","false", "K11",  "good", "ok", "bad", "A");
K12=new studentSeat("Jilly","ok","false","false", "K12",  "good", "ok", "bad", "A");
K13=new studentSeat("Johnny","bad","false","false", "K13",  "good", "ok", "bad", "A");
K14=new studentSeat("Jimmy","good","false","false", "K14",  "good", "ok", "bad", "A");

var studArray = new Array();
studArray[0]=new studentSeat("Johnny","bad","false","false", "A1", "good", "ok", "bad", "A");
studArray[1]=new studentSeat("Johnny","bad","false","false", "A1", "good", "ok", "bad", "A");
studArray[2]=new studentSeat("Johnny","bad","false","false", "A1", "good", "ok", "bad", "A");
studArray[3]=new studentSeat("Johnny","bad","false","false", "A1", "good", "ok", "bad", "A");
studArray[4]=new studentSeat("Johnny","bad","false","false", "A1", "good", "ok", "bad", "A");
studArray[5]=new studentSeat("Johnny","bad","false","false", "A1", "good", "ok", "bad", "A");
studArray[6]=new studentSeat("Johnny","bad","false","false", "A1", "good", "ok", "bad", "A");
studArray[7]=new studentSeat("Jimmy","good","false","false", "A8",  "good", "ok", "bad", "A");
studArray[8]=new studentSeat("Jilly","ok","false","false", "A9",  "good", "ok", "bad", "A");
studArray[9]=new studentSeat("Johnny","bad","false","false", "A10",  "good", "ok", "bad", "A");
studArray[10]=new studentSeat("Jimmy","good","false","false", "A11",  "good", "ok", "bad", "A");
studArray[11]=new studentSeat("NULL","NULL","false","false", "A12",  "good", "ok", "bad", "A");
studArray[12]=new studentSeat("Johnny","bad","false","false", "A13",  "good", "ok", "bad", "A");
studArray[13]=new studentSeat("Jimmy","good","false","false", "A14",  "good", "ok", "bad", "A");

studArray[14]=new studentSeat("Johnny","bad","false","false", "B1",  "good", "ok", "bad", "A");
studArray[15]=new studentSeat("Jimmy","good","false","false", "B2",  "good", "ok", "bad", "A");
studArray[16]=new studentSeat("Jilly","ok","false","false", "B3",  "good", "ok", "bad", "A");
studArray[17]=new studentSeat("Johnny","bad","false","false", "B4",  "good", "ok", "bad", "A");
studArray[18]=new studentSeat("Jimmy","good","false","false", "B5",  "good", "ok", "bad", "A");
studArray[19]=new studentSeat("Jilly","ok","false","false", "B6",  "good", "ok", "bad", "A");
studArray[20]=new studentSeat("Johnny","bad","false","false", "B7",  "good", "ok", "bad", "A");
studArray[21]=new studentSeat("Jimmy","good","false","false", "B8",  "good", "ok", "bad", "A");
studArray[22]=new studentSeat("Jilly","ok","false","false", "B9",  "good", "ok", "bad", "A");
studArray[23]=new studentSeat("Johnny","bad","false","false", "B10",  "good", "ok", "bad", "A");
studArray[24]=new studentSeat("Jimmy","good","false","false", "B11",  "good", "ok", "bad", "A");
studArray[25]=new studentSeat("Jilly","ok","false","false", "B12",  "good", "ok", "bad", "A");
studArray[26]=new studentSeat("NULL","NULL","false","false", "B13",  "good", "ok", "bad", "A");
studArray[27]=new studentSeat("NULL","NULL","false","false", "B14",  "good", "ok", "bad", "A");

studArray[28]=new studentSeat("Johnny","bad","false","false", "C1",  "good", "ok", "bad", "A");
studArray[29]=new studentSeat("Jimmy","good","false","false", "C2",  "good", "ok", "bad", "A");
studArray[30]=new studentSeat("Jilly","ok","false","false", "C3",  "good", "ok", "bad", "A");
studArray[31]=new studentSeat("Johnny","bad","false","false", "C4",  "good", "ok", "bad", "A");
studArray[32]=new studentSeat("Jimmy","good","false","false", "C5",  "good", "ok", "bad", "A");
studArray[33]=new studentSeat("Jilly","ok","false","false", "C6",  "good", "ok", "bad", "A");
studArray[34]=new studentSeat("Johnny","bad","false","false", "C7",  "good", "ok", "bad", "A");
studArray[35]=new studentSeat("Jimmy","good","false","false", "C8",  "good", "ok", "bad", "A");
studArray[36]=new studentSeat("Jilly","ok","false","false", "C9",  "good", "ok", "bad", "A");
studArray[37]=new studentSeat("Johnny","bad","false","false", "C10",  "good", "ok", "bad", "A");
studArray[38]=new studentSeat("Jimmy","good","false","false", "C11",  "good", "ok", "bad", "A");
studArray[39]=new studentSeat("Jilly","ok","false","false", "C12",  "good", "ok", "bad", "A");
studArray[40]=new studentSeat("Johnny","bad","false","false", "C13",  "good", "ok", "bad", "A");
studArray[41]=new studentSeat("NULL","NULL","false","false", "C14",  "good", "ok", "bad", "A");

studArray[42]=new studentSeat("Johnny","bad","false","false", "D1",  "good", "ok", "bad", "A");
studArray[43]=new studentSeat("Jimmy","good","false","false", "D2",  "good", "ok", "bad", "A");
studArray[44]=new studentSeat("Jilly","ok","false","false", "D3",  "good", "ok", "bad", "A");
studArray[45]=new studentSeat("Johnny","bad","false","false", "D4",  "good", "ok", "bad", "A");
studArray[46]=new studentSeat("Jimmy","good","false","false", "D5",  "good", "ok", "bad", "A");
studArray[47]=new studentSeat("Jilly","ok","false","false", "D6",  "good", "ok", "bad", "A");
studArray[48]=new studentSeat("Johnny","bad","false","false", "D7",  "good", "ok", "bad", "A");
studArray[49]=new studentSeat("Jimmy","good","false","false", "D8",  "good", "ok", "bad", "A");
studArray[50]=new studentSeat("Jilly","ok","false","false", "D9",  "good", "ok", "bad", "A");
studArray[51]=new studentSeat("NULL","NULL","false","false", "D10",  "good", "ok", "bad", "A");
studArray[52]=new studentSeat("Jimmy","good","false","false", "D11",  "good", "ok", "bad", "A");
studArray[53]=new studentSeat("Jilly","ok","false","false", "D12",  "good", "ok", "bad", "A");
studArray[54]=new studentSeat("Johnny","bad","false","false", "D13",  "good", "ok", "bad", "A");
studArray[55]=new studentSeat("Jimmy","good","false","false", "D14",  "good", "ok", "bad", "A");

studArray[56]=new studentSeat("NULL","NULL","false","false", "E1",  "good", "ok", "bad", "A");
studArray[57]=new studentSeat("Jimmy","good","false","false", "E2",  "good", "ok", "bad", "A");
studArray[58]=new studentSeat("Jilly","ok","false","false", "E3",  "good", "ok", "bad", "A");
studArray[59]=new studentSeat("Johnny","bad","false","false", "E4",  "good", "ok", "bad", "A");
studArray[60]=new studentSeat("Jimmy","good","false","false", "E5",  "good", "ok", "bad", "A");
studArray[61]=new studentSeat("Jilly","ok","false","false", "E6",  "good", "ok", "bad", "A");
studArray[62]=new studentSeat("Johnny","bad","false","false", "E7",  "good", "ok", "bad", "A");
studArray[63]=new studentSeat("NULL","NULL","false","false", "E8",  "good", "ok", "bad", "A");
studArray[64]=new studentSeat("Jilly","ok","false","false", "E9",  "good", "ok", "bad", "A");
studArray[64]=new studentSeat("Johnny","bad","false","false", "E10",  "good", "ok", "bad", "A");
studArray[65]=new studentSeat("Jimmy","good","false","false", "E11",  "good", "ok", "bad", "A");
studArray[66]=new studentSeat("Jilly","ok","false","false", "E12",  "good", "ok", "bad", "A");
studArray[67]=new studentSeat("Johnny","bad","false","false", "E13",  "good", "ok", "bad", "A");
studArray[68]=new studentSeat("Jimmy","good","false","false", "E14",  "good", "ok", "bad", "A");

studArray[69]=new studentSeat("Johnny","bad","false","false", "F1",  "good", "ok", "bad", "A");
studArray[70]=new studentSeat("Jimmy","good","false","false", "F2",  "good", "ok", "bad", "A");
studArray[71]=new studentSeat("Jilly","ok","false","false", "F3",  "good", "ok", "bad", "A");
studArray[72]=new studentSeat("Johnny","bad","false","false", "F4",  "good", "ok", "bad", "A");
studArray[73]=new studentSeat("Jimmy","good","false","false", "F5",  "good", "ok", "bad", "A");
studArray[74]=new studentSeat("Jilly","ok","false","false", "F6",  "good", "ok", "bad", "A");
studArray[75]=new studentSeat("Johnny","bad","false","false", "F7",  "good", "ok", "bad", "A");
studArray[76]=new studentSeat("Jimmy","good","false","false", "F8",  "good", "ok", "bad", "A");
studArray[77]=new studentSeat("Jilly","ok","false","false", "F9",  "good", "ok", "bad", "A");
studArray[78]=new studentSeat("Johnny","bad","false","false", "F10",  "good", "ok", "bad", "A");
studArray[79]=new studentSeat("Jimmy","good","false","false", "F11",  "good", "ok", "bad", "A");
studArray[80]=new studentSeat("Jilly","ok","false","false", "F12",  "good", "ok", "bad", "A");
studArray[81]=new studentSeat("Johnny","bad","false","false", "F13",  "good", "ok", "bad", "A");
studArray[82]=new studentSeat("Jimmy","good","false","false", "F14",  "good", "ok", "bad", "A");

studArray[83]=new studentSeat("Johnny","bad","false","false", "G1",  "good", "ok", "bad", "A");
studArray[84]=new studentSeat("Jimmy","good","false","false", "G2",  "good", "ok", "bad", "A");
studArray[85]=new studentSeat("Jilly","ok","false","false", "G3",  "good", "ok", "bad", "A");
studArray[86]=new studentSeat("Johnny","bad","false","false", "G4",  "good", "ok", "bad", "A");
studArray[87]=new studentSeat("Jimmy","good","false","false", "G5",  "good", "ok", "bad", "A");
studArray[88]=new studentSeat("Jilly","ok","false","false", "G6",  "good", "ok", "bad", "A");
studArray[89]=new studentSeat("Johnny","bad","false","false", "G7",  "good", "ok", "bad", "A");
studArray[90]=new studentSeat("Jimmy","good","false","false", "G8",  "good", "ok", "bad", "A");
studArray[91]=new studentSeat("Jilly","ok","false","false", "G9",  "good", "ok", "bad", "A");
studArray[92]=new studentSeat("Johnny","bad","false","false", "G10",  "good", "ok", "bad", "A");
studArray[93]=new studentSeat("Jimmy","good","false","false", "G11",  "good", "ok", "bad", "A");
studArray[94]=new studentSeat("Jilly","ok","false","false", "G12",  "good", "ok", "bad", "A");
studArray[95]=new studentSeat("Johnny","bad","false","false", "G13",  "good", "ok", "bad", "A");
studArray[96]=new studentSeat("Jimmy","good","false","false", "G14",  "good", "ok", "bad", "A");

studArray[97]=new studentSeat("Johnny","bad","false","false", "H1",  "good", "ok", "bad", "A");
studArray[98]=new studentSeat("Jimmy","good","false","false", "H2",  "good", "ok", "bad", "A");
studArray[99]=new studentSeat("Jilly","ok","false","false", "H3",  "good", "ok", "bad", "A");
studArray[100]=new studentSeat("Johnny","bad","false","false", "H4",  "good", "ok", "bad", "A");
studArray[101]=new studentSeat("Jimmy","good","false","false", "H5",  "good", "ok", "bad", "A");
studArray[102]=new studentSeat("Jilly","ok","false","false", "H6",  "good", "ok", "bad", "A");
studArray[103]=new studentSeat("Johnny","bad","false","false", "H7",  "good", "ok", "bad", "A");
studArray[104]=new studentSeat("Jimmy","good","false","false", "H8",  "good", "ok", "bad", "A");
studArray[105]=new studentSeat("Jilly","ok","false","false", "H9",  "good", "ok", "bad", "A");
studArray[106]=new studentSeat("Johnny","bad","false","false", "H10",  "good", "ok", "bad", "A");
studArray[107]=new studentSeat("Jimmy","good","false","false", "H11",  "good", "ok", "bad", "A");
studArray[108]=new studentSeat("Jilly","ok","false","false", "H12",  "good", "ok", "bad", "A");
studArray[109]=new studentSeat("Johnny","bad","false","false", "H13",  "good", "ok", "bad", "A");
studArray[110]=new studentSeat("Jimmy","good","false","false", "H14",  "good", "ok", "bad", "A");

studArray[111]=new studentSeat("NULL","NULL","false","false", "I1",  "good", "ok", "bad", "A");
studArray[112]=new studentSeat("Jimmy","good","false","false", "I2",  "good", "ok", "bad", "A");
studArray[113]=new studentSeat("Jilly","ok","false","false", "I3",  "good", "ok", "bad", "A");
studArray[114]=new studentSeat("Johnny","bad","false","false", "I4",  "good", "ok", "bad", "A");
studArray[115]=new studentSeat("Jimmy","good","false","false", "I5",  "good", "ok", "bad", "A");
studArray[116]=new studentSeat("NULL","NULL","false","false", "I6",  "good", "ok", "bad", "A");
studArray[117]=new studentSeat("Johnny","bad","false","false", "I7",  "good", "ok", "bad", "A");
studArray[118]=new studentSeat("Jimmy","good","false","false", "I8",  "good", "ok", "bad", "A");
studArray[119]=new studentSeat("Jilly","ok","false","false", "I9",  "good", "ok", "bad", "A");
studArray[120]=new studentSeat("Johnny","bad","false","false", "I10",  "good", "ok", "bad", "A");
studArray[121]=new studentSeat("Jimmy","good","false","false", "I11",  "good", "ok", "bad", "A");
studArray[122]=new studentSeat("Jilly","ok","false","false", "I12",  "good", "ok", "bad", "A");
studArray[123]=new studentSeat("Johnny","bad","false","false", "I13",  "good", "ok", "bad", "A");
studArray[124]=new studentSeat("Jimmy","good","false","false", "I14",  "good", "ok", "bad", "A");

studArray[125]=new studentSeat("Johnny","bad","false","false", "J1",  "good", "ok", "bad", "A");
studArray[126]=new studentSeat("Jimmy","good","false","false", "J2",  "good", "ok", "bad", "A");
studArray[127]=new studentSeat("Jilly","ok","false","false", "J3",  "good", "ok", "bad", "A");
studArray[128]=new studentSeat("Johnny","bad","false","false", "J4",  "good", "ok", "bad", "A");
studArray[129]=new studentSeat("NULL","NULL","false","false", "J5",  "good", "ok", "bad", "A");
studArray[130]=new studentSeat("Jilly","ok","false","false", "J6",  "good", "ok", "bad", "A");
studArray[131]=new studentSeat("Johnny","bad","false","false", "J7",  "good", "ok", "bad", "A");
studArray[132]=new studentSeat("Jimmy","good","false","false", "J8",  "good", "ok", "bad", "A");
studArray[133]=new studentSeat("Jilly","ok","false","false", "J9",  "good", "ok", "bad", "A");
studArray[134]=new studentSeat("Johnny","bad","false","false", "J10",  "good", "ok", "bad", "A");
studArray[135]=new studentSeat("Jimmy","good","false","false", "J11",  "good", "ok", "bad", "A");
studArray[136]=new studentSeat("Jilly","ok","false","false", "J12",  "good", "ok", "bad", "A");
studArray[137]=new studentSeat("Johnny","bad","false","false", "J13",  "good", "ok", "bad", "A");
studArray[138]=new studentSeat("Jimmy","good","false","false", "J14",  "good", "ok", "bad", "A");

studArray[139]=new studentSeat("Johnny","bad","false","false", "K1",  "good", "ok", "bad", "A");
studArray[140]=new studentSeat("Jimmy","good","false","false", "K2",  "good", "ok", "bad", "A");
studArray[141]=new studentSeat("Jilly","ok","false","false", "K3",  "good", "ok", "bad", "A");
studArray[142]=new studentSeat("Johnny","bad","false","false", "K4",  "good", "ok", "bad", "A");
studArray[143]=new studentSeat("Jimmy","good","false","false", "K5",  "good", "ok", "bad", "A");
studArray[144]=new studentSeat("Jilly","ok","false","false", "K6",  "good", "ok", "bad", "A");
studArray[145]=new studentSeat("Johnny","bad","false","false", "K7",  "good", "ok", "bad", "A");
studArray[146]=new studentSeat("NULL","NULL","false","false", "K8",  "good", "ok", "bad", "A");
studArray[147]=new studentSeat("NULL","NULL","false","false", "K9",  "good", "ok", "bad", "A");
studArray[148]=new studentSeat("Johnny","bad","false","false", "K10",  "good", "ok", "bad", "A");
studArray[149]=new studentSeat("Jimmy","good","false","false", "K11",  "good", "ok", "bad", "A");
studArray[150]=new studentSeat("Jilly","ok","false","false", "K12",  "good", "ok", "bad", "A");
studArray[151]=new studentSeat("Johnny","bad","false","false", "K13",  "good", "ok", "bad", "A");
studArray[152]=new studentSeat("Jimmy","good","false","false", "K14",  "good", "ok", "bad", "A");


function seatcolor(id, student) {
x=document.getElementById(id)  //Find the element 
//x.style.background="green";           //Change the style
//x.style.color="white";
//value = StudentArray.indexOf(id);
var pathArray = document.URL;
var average_pre = pathArray.split('=');
var average = average_pre[1];
if (average == null){

	if (student.overallaverage == "bad")
	{
		x.style.background="#E42121";
		x.style.color="white";
	}
	else if (student.overallaverage=="ok")
	{
		x.style.background="#EAF11C";
		x.style.color="black";
	}
	else if (student.overallaverage=="good")
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
if (student.homeworkAverage == "bad")
	{
		x.style.background="#E42121";
		x.style.color="white";
	}
	else if (student.homeworkAverage =="ok")
	{
		x.style.background="#EAF11C";
		x.style.color="black";
	}
	else if (student.homeworkAverage=="good")
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
if (student.examAverage == "bad")
	{
		x.style.background="#E42121";
		x.style.color="white";
	}
	else if (student.examAverage =="ok")
	{
		x.style.background="#EAF11C";
		x.style.color="black";
	}
	else if (student.examAverage=="good")
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
if (student.labAverage == "bad")
	{
		x.style.background="#E42121";
		x.style.color="white";
	}
	else if (student.labAverage=="ok")
	{
		x.style.background="#EAF11C";
		x.style.color="black";
	}
	else if (student.labAverage=="good")
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

}         //Change the style

//var test = K5.name;

//create function that opens up the popup if the seat isn't empty
function seatPopup(id, student)
{
	if (student.name != "NULL")
	{
	preurl = 'student_stats.html?id=';
	url = preurl + id;
	window.open(url,'popUpWindow','height=500,width=800,left=300,top=100,resizable=no,scrollbars=no,toolbar=no,menubar=no,location=0, directories=no, status=no');
	}

}

function seatName(id, student)
{
	if(student.name != "NULL")
	{
		document.write(student.name);
	}
	else
	{
		document.write("<br>");
	}
}


