import { Component, OnInit } from '@angular/core';
import { TaskService } from './services/task.service';
import { Observable } from 'rxjs';
import { TaskModel } from './models/task.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [TaskService],
})

export class AppComponent implements OnInit {
  
  title = 'todo-app';
  tasks: Observable<TaskModel[]>;

  ngOnInit(): void {
    this.tasks = this.taskService.getTasks();
  }

  constructor(public taskService: TaskService) {}

  toggleDoneUnDone(task: TaskModel) {
    task.Done = !task.Done;
  }

  addTask(desc: string) {
    if (desc !== '') { 
    }
  }

  removeTask(task: TaskModel) {
    
  }

}
