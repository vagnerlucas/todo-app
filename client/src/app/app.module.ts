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
import { SocketService } from './services/socket.service';

import { TaskComponent } from './components/task/task.component';
import { UserComponent } from './components/user/user.component';

import { SignalRModule } from 'ng2-signalr';
import { SignalRConfiguration } from 'ng2-signalr';
import { environment } from 'src/environments/environment';
import { JokeComponent } from './components/joke/joke.component';

@NgModule({
  declarations: [
    AppComponent,
    OrderByDatePipe,
    FilterTaskPipe,
    UserNameModalContent,
    TaskComponent,
    UserComponent,
    JokeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    NgbModule,
    SignalRModule.forRoot(createConfig)
  ],
  providers: [
    HttpClient,
    HttpService,
    UserService,
    SocketService
  ],
  entryComponents: [
    UserNameModalContent
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }

export function createConfig(): SignalRConfiguration {
  const c = new SignalRConfiguration();
  c.url = `${environment.hubUrl}/r`;
  c.hubName = "TodoAppHub";
  return c;
}
