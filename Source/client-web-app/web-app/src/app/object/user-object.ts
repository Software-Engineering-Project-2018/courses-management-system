import { BaseObject } from './base-object';

export class UserObject extends BaseObject {
    UserId: number;
    UserPw: string;
    UserName: string;
    UserFullName: string;
    UserDob: Date;
    UserGender: number; // 1: Male, 2: Female, 0 or null: Other
    UserAddress: string;
    UserMobile: string;
    UserEmail: string;
    UserAvatar: string;
    UserType: number; // 1: Manager, 2: Teacher, 3: stdent, 4: Parent

    constructor() {
        super();
        this.UserDob = new Date();
        this.UserType = 3;
        this.UserGender = 3;
    }
}
