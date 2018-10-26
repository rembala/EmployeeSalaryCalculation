import { Component, Input, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Router } from '@angular/router';
import { Location} from '@angular/common';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  @Input() EmployeeList: EmployeeList[];

  constructor(http: HttpClient, public dialog: MatDialog, @Inject('BASE_URL') baseUrl: string) {
    http.get<EmployeeList[]>(baseUrl + 'api/Employee/GetEmployeeList').subscribe(result => {
      this.EmployeeList = result;
    }, error => console.error(error));
  }

  animal: string;
  name: string;

  openDialog(latYearSatisfaction): void {
    const dialogRef = this.dialog.open(DialogOverviewExampleDialog, {
      width: '650px',
      data: latYearSatisfaction
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.animal = result;
    });
  }
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

  CompleteData: string;

  constructor(
    public location: Location,
    public http: HttpClient,
    public router: Router,
    @Inject('BASE_URL') public baseUrl: string,
    public dialogRef: MatDialogRef<DialogOverviewExampleDialog>,
    @Inject(MAT_DIALOG_DATA) public employeeMaxYearSatisfaction: EmployeeMaxYearSatisfaction) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onCloseConfirm(yearsWorkedId, satisfactionScore) {
    this.http.post(this.baseUrl + 'api/Employee/ChangeSatisfactionScore', { SatisfactionScore: satisfactionScore, YearsWorkedId: yearsWorkedId }).subscribe(result => {
      location.reload();
    }, error => console.error(error));
    this.dialogRef.close('Confirm');
  }
  
  onCloseCancel() {
    this.dialogRef.close('Cancel');
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
  employeeMaxYearViewModel: EmployeeMaxYearSatisfaction
}

interface YearsSatisfactions {
  SatisfactionScore: number;
  YearsWorked: string
}

interface EmployeeMaxYearSatisfaction {
  YearsWorkedId: number;
  MaxYear: string;
  SatisfactionScore: number;
}
