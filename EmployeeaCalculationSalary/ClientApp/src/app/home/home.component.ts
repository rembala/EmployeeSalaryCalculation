import { Component, Input, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { NgxSpinnerService } from 'ngx-spinner';
import { ValidationComponentComponent } from '../validation-component/validation-component.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  @Input() EmployeeList: EmployeeList[];

  constructor(
    http: HttpClient,
    public dialog: MatDialog,
    private spinner: NgxSpinnerService,
    @Inject('BASE_URL') baseUrl: string) {
    this.spinner.show();

    http.get<EmployeeList[]>(baseUrl + 'api/Employee/GetEmployeeList').subscribe(result => {
      this.spinner.hide();
      this.EmployeeList = result;
    }, error => { console.error(error); this.spinner.hide(); });
  }

  openDialog(latYearSatisfaction): void {

    const dialogRef = this.dialog.open(EmployeeDialogComponent, {
      width: '650px',
      data: latYearSatisfaction
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }
}

@Component({
  selector: 'dialog-overview-example-dialog',
  templateUrl: './employee.satisfactions.html',
  styleUrls: ['./home.component.css']
})
export class EmployeeDialogComponent {

  MessageError: string;

  constructor(
    public location: Location,
    public http: HttpClient,
    public router: Router,
    public dialog: MatDialog,
    @Inject('BASE_URL') public baseUrl: string,
    public dialogRef: MatDialogRef<EmployeeDialogComponent>,
    public validationDialog: MatDialogRef<ValidationComponentComponent>,
    @Inject(MAT_DIALOG_DATA) public employeeMaxYearSatisfaction: EmployeeMaxYearSatisfaction) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onCloseConfirm(yearsWorkedId, satisfactionScore) {
    this.MessageError = null;
    if (satisfactionScore != '' && satisfactionScore >= 0 && satisfactionScore <= 5) {
      this.http.post(this.baseUrl + 'api/Employee/ChangeSatisfactionScore', { SatisfactionScore: satisfactionScore, YearsWorkedId: yearsWorkedId }).subscribe(result => {
        location.reload();
      }, error => { console.error(error); });
      this.dialogRef.close('Confirm');
    }
    else {
      this.MessageError = "The value must be numeric and must be from 0 to 5";
    }
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
