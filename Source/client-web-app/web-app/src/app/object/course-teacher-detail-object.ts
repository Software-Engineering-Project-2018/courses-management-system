import { BaseObject } from './base-object';
import { TeacherObject } from './teacher-object';
import { CourseObject } from './Course-object';

export class CourseTeacherDetailObject extends BaseObject {
    CourseSTeacherDetailId: number;
    Course: CourseObject;
    Teacher: TeacherObject;
    FinalScore: number;
    public constructor() {
        super();
        this.Course = new CourseObject();
        this.Teacher = new TeacherObject();
    }
}
