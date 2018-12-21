import { BaseObject } from './base-object';
import { TeacherObject } from './teacher-object';
import { CourseObject } from './Course-object';

export class DocumentObject extends BaseObject {
    DocumentDetailId: number;
    Course: CourseObject;
    Teacher: TeacherObject;
    DocumentDetailFileUpload: string;
    public constructor() {
        super();
        this.Course = new CourseObject();
        this.Teacher = new TeacherObject();
    }
}
