import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { DialogOverviewExampleDialog } from './home/home.component';
import { EmployeeComponentComponent } from './employee-component/employee-component.component';
import { DialogDemoComponent } from './dialog-demo/dialog-demo.component';
import { MatCardModule } from '@angular/material';
import { MatButtonModule } from '@angular/material';
import { MatDialogModule } from '@angular/material';
import { MyDialogComponent } from './my-dialog/my-dialog.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxSpinnerModule } from 'ngx-spinner';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    EmployeeComponentComponent,
    DialogDemoComponent,
    MyDialogComponent,
    DialogOverviewExampleDialog
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    MatCardModule,
    MatButtonModule,
    MatDialogModule,
    NgxSpinnerModule,
    MatTableModule,
    FormsModule,
    BrowserAnimationsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' }
    ])
  ],
  entryComponents: [
    DialogOverviewExampleDialog
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
