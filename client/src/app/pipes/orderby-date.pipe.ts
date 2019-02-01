import { Pipe, PipeTransform } from '@angular/core';
import { TaskModel } from '../models/task.model';
import { Observable } from 'rxjs';

@Pipe({
  name: 'orderByDate'
})

export class OrderByDatePipe implements PipeTransform {

  transform(tasks: TaskModel[]): TaskModel[] {
    if (tasks != null) {
      tasks.sort((a: TaskModel, b: TaskModel) => {
        return a.CreatedAt.valueOf() - b.CreatedAt.valueOf();
      });

      return tasks;
    }
  }
}
