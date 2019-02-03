import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { HttpService } from './services/http.service';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClient, HttpHandler, HttpClientModule } from '@angular/common/http';

import { OrderByDatePipe } from './pipes/orderby-date.pipe';
import { FilterTaskPipe } from './pipes/filter-task.pipe';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { UserNameModalContent } from './modals/username.modal.content';
import { UserService } from './services/user.service';
import { TaskComponent } from './components/task/task.component';
import { UserComponent } from './components/user/user.component';

@NgModule({
  declarations: [
    AppComponent,
    OrderByDatePipe,
    FilterTaskPipe,
    UserNameModalContent,
    TaskComponent,
    UserComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    NgbModule
  ],
  providers: [
    HttpClient,
    HttpService,
    UserService
  ],
  entryComponents: [
    UserNameModalContent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
