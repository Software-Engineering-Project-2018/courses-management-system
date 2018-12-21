import { BaseObject } from './base-object';
import { CourseObject } from './Course-object';
import { StudentObject } from './student-object';
import { TaskObject } from './task-object';

export class TaskDetailObject extends BaseObject {
    TaskDetailId: number;
    Student: StudentObject;
    Task: TaskObject;
    TaskFileUpload: string;
    TaskSubmissionState: boolean;
    TaskScore: number;
    public constructor() {
        super();
        this.Student = new StudentObject();
        this.Task = new TaskObject();
    }
}
