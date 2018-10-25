import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  public EmployeeList: EmployeeList[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<EmployeeList[]>(baseUrl + 'api/Employee/GetEmployeeList').subscribe(result => {
      this.EmployeeList = result;
    }, error => console.error(error));
  }
}

interface EmployeeList {
  employeename: string;
  employeemanager: number;
  position: number;
  satisfactionaverage: number;
  currentsalary: number;
  salaryAftercalculation: number;
}
