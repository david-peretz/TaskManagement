
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TaskService } from '../services/task.service';
import { User } from '../models/user.model';
import { Task } from '../models/task.model';

@Component({
  selector: 'app-task-form',
  templateUrl: './task-form.component.html',
  styleUrls: ['./task-form.component.css']
})
export class TaskFormComponent implements OnInit {
  taskForm: FormGroup;
  users: User[] = [];

  constructor(private fb: FormBuilder, private taskService: TaskService) {
    this.taskForm = this.fb.group({
      userId: ['', Validators.required],
      subject: ['', Validators.required],
      targetDate: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.taskService.getUsers().subscribe(users => {
      this.users = users;
    });
  }

  onSubmit(): void {
    if (this.taskForm.valid) {
      const newTask: Task = {
        id: 0,
        userId: this.taskForm.get('userId')!.value,
        subject: this.taskForm.get('subject')!.value,
        targetDate: this.taskForm.get('targetDate')!.value,
        isCompleted: false
      };
      this.taskService.addTask(newTask).subscribe(() => {
        this.taskForm.reset();
      });
    }
  }
}
