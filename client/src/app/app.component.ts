import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { TaskService } from './services/task.service';
import { Observable, BehaviorSubject } from 'rxjs';
import { TaskModel } from './models/task.model';
import { UserNameModalContent } from './modals/username.modal.content';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { UserNotFoundException } from './exceptions/user.exception';
import { UserModel } from './models/user.model';
import { UserService } from './services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [TaskService]
})

export class AppComponent implements OnInit {

  title = 'todo-app';
  tasks: Observable<TaskModel[]>;
  user: Observable<UserModel>;
  hasUserCredentials : boolean;

  constructor(private taskService: TaskService, private userService: UserService, private modalService: NgbModal) { 
    this.userService.checkLogin.subscribe(result => this.hasUserCredentials = result);
  }

  ngOnInit(): void {
    try {
      this.tasks = this.taskService.getTasks();
    } catch (e) {
      if (e instanceof UserNotFoundException)
      {
        this.hasUserCredentials = false;
        console.error('User not found');
      }
    }
  }

  openModal() {
    const modalRef = this.modalService.open(UserNameModalContent);
    modalRef.result.then(result => {
      if (result) {
        const user = new UserModel();
        user.Name = result;
        this.userService.createUser(user);
        this.ngOnInit();
      }
    });
  }

  hasCredentials() {
    return sessionStorage.getItem('X-User-Id') && sessionStorage.getItem('X-User-Id') !== '';
  }

  toggleDoneUnDone(task: TaskModel) {
    task.Done = !task.Done;
  }

  addTask(desc: string) {
    if (desc !== '') {
      const task = new TaskModel();
      task.Name = desc;
      this.taskService
          .createTask(task)
          .subscribe(task => this.tasks = this.taskService.getTasks());
    }
  }

  removeTask(task: TaskModel) {

  }

}
