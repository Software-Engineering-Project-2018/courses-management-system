import { BaseObject } from './base-object';
import { DocumentObject } from './document-detail-object';
import { TaskDetailObject } from './task-detail-object';
import { TaskObject } from './task-object';
import { TeacherObject } from './teacher-object';

export class CourseObject extends BaseObject {

    CourseId: number;
    CourseName: string;
    DateStart: Date;
    DateEnd: Date;
    Tutition: number;
    CourseIntro: string;
    CourseLinkRef: string;
    TeacherList: TeacherObject[];
    DocumentDetailList: DocumentObject[];
    TaskList: TaskObject[];
    public constructor() {
        super();
        this.DateStart = new Date();
        this.DateEnd = new Date();
        this.DocumentDetailList = [];
        this.TaskList = [];
    }
}
