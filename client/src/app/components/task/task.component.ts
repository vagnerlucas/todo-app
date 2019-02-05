import { Component, OnInit } from '@angular/core';
import { TaskService } from 'src/app/services/task.service';
import { Observable, Subject } from 'rxjs';
import { TaskModel } from 'src/app/models/task.model';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit {

  tasks = new Subject<TaskModel[]>();
  name: string

  constructor(private taskService: TaskService) { }

  private updateTaskList = (tasks) => this.tasks.next(tasks);

  ngOnInit() {
    try {
      this.taskService.getTasks()
                      .subscribe(this.updateTaskList);
    } catch (error) { }
  }
  
  toggleDoneUnDone(task: TaskModel) {
    task.Done = !task.Done;
    this.taskService.markAsDone(task).subscribe(_ => {
      this.taskService.getTasks()
                      .subscribe(this.updateTaskList)
    });
  }

  addTask(desc: string) {
    if (desc !== '') {
      const task = new TaskModel();
      task.Name = desc;
      this.taskService
        .createTask(task)
        .subscribe(task => this.taskService.getTasks()
                                           .subscribe(this.updateTaskList));
    }
  }

  removeTask(task: TaskModel) {
    this.taskService.remove(task).subscribe(_ => {
      this.taskService.getTasks()
                      .subscribe(this.updateTaskList);
    });
  }
}
