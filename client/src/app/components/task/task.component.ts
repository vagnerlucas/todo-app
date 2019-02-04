import { Component, OnInit } from '@angular/core';
import { TaskService } from 'src/app/services/task.service';
import { Observable } from 'rxjs';
import { TaskModel } from 'src/app/models/task.model';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit {

  tasks: Observable<TaskModel[]>;

  constructor(private taskService: TaskService) { }

  ngOnInit() {
    try {
      this.tasks = this.taskService.getTasks();
    } catch (error) { }
  }
  
  toggleDoneUnDone(task: TaskModel) {
    task.Done = !task.Done;
    this.taskService.markAsDone(task).subscribe(_ => {
      this.tasks = this.taskService.getTasks();
    });
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
    this.taskService.remove(task).subscribe(_ => {
      this.tasks = this.taskService.getTasks();
    });
  }
}
