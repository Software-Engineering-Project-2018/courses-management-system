import { BaseObject } from './base-object';
import { CourseObject } from './Course-object';

export class TaskObject extends BaseObject {
    TaskId: number;
    TaskName: string;
    TaskDesctiption: string;
    TaskContent: string;
    TaskDateStart: Date;
    TaskDeadline: Date;
    TaskDateSubmission: Date;
    Course: CourseObject;
    public constructor() {
        super();
        this.Course = new CourseObject();
    }
}
