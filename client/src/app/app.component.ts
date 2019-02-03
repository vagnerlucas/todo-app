import { Component, OnInit, ViewChild, AfterViewInit, ChangeDetectorRef, AfterViewChecked } from '@angular/core';
import { TaskService } from './services/task.service';
import { Observable, BehaviorSubject } from 'rxjs';
import { TaskModel } from './models/task.model';
import { UserNameModalContent } from './modals/username.modal.content';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { UserNotFoundException, UserCreationException } from './exceptions/user.exception';
import { UserModel } from './models/user.model';
import { UserService } from './services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [TaskService]
})

export class AppComponent  {
  title = 'todo-app';
}
