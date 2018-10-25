import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  public EmployeeList: EmployeeList[];

  constructor(http: HttpClient, public dialog: MatDialog, @Inject('BASE_URL') baseUrl: string) {
    http.get<EmployeeList[]>(baseUrl + 'api/Employee/GetEmployeeList').subscribe(result => {
      this.EmployeeList = result;
    }, error => console.error(error));
  }

  animal: string;
  name: string;

  openDialog(YearsSatisfactions): void {
    const dialogRef = this.dialog.open(DialogOverviewExampleDialog, {
      width: '250px',
      data: YearsSatisfactions
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.animal = result;
    });
  }

  ////openDialog(param): void {
  ////  const dialogRef = this.dialog.open(DialogOverviewExampleDialog, {
  ////    width: '250px',
  ////    data: { name: this.name, animal: this.animal }
  ////  });

  ////  dialogRef.afterClosed().subscribe(result => {
  ////    console.log('The dialog was closed');
  ////    this.animal = result;
  ////  });
  ////}

}

export interface DialogData {
  animal: string;
  name: string;
}

@Component({
  selector: 'dialog-overview-example-dialog',
  templateUrl: './employee.satisfactions.html',
  styleUrls: ['./home.component.css']
})
export class DialogOverviewExampleDialog {

  constructor(
    public dialogRef: MatDialogRef<DialogOverviewExampleDialog>,
    @Inject(MAT_DIALOG_DATA) public data: YearsSatisfactions) { }

  onNoClick(): void {
    this.dialogRef.close();
  }
}

interface EmployeeList {
  employeename: string;
  employeemanager: number;
  position: number;
  satisfactionaverage: number;
  currentsalary: number;
  salaryAftercalculation: number;
  yearsSatisfactions: YearsSatisfactions;
}

interface YearsSatisfactions {
  employeeid: number;
  SatisfactionScore: number;
  YearsWorked: string
}
