import { Pipe, PipeTransform } from '@angular/core';
import { TaskModel } from '../models/task.model';

@Pipe({
  name: 'filterTask'
})
export class FilterTaskPipe implements PipeTransform {

  transform(tasks: TaskModel[], desc: string): TaskModel[] {
    if (tasks != null) {
      tasks.sort((a: TaskModel, b: TaskModel) => {
        return a.CreatedAt.valueOf() - b.CreatedAt.valueOf();
      });

      if (desc && desc !== '') {
        desc = desc.toLowerCase();

        return tasks.filter(it => {
          return it.Name.toLowerCase().includes(desc);
        });
      }
      
      return tasks;
    }
  }

}
