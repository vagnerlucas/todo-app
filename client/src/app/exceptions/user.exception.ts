export class UserNotFoundException extends Error
{
    constructor(message) 
    {
        super(message);
        Object.setPrototypeOf(this, UserNotFoundException.prototype);
    }
}