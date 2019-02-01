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
import { UsernameModal } from './modals/username.modal';

@NgModule({
  declarations: [
    AppComponent,
    OrderByDatePipe,
    FilterTaskPipe,
    UsernameModal
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
    HttpService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
