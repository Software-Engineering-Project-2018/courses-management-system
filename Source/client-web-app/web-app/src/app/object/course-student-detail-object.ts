import { BaseObject } from './base-object';
import { StudentObject } from './student-object';
import { CourseObject } from './Course-object';

export class CourseStudentObject extends BaseObject {
    CourseStudentDetailId: number;
    Course: CourseObject;
    Student: StudentObject;
    FinalScore: number;
    public constructor() {
        super();
        this.Course = new CourseObject();
        this.Student = new StudentObject();
    }
}
