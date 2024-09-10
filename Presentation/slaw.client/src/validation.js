import { object, string, number, date, InferType } from 'yup';

const contactFormSchema = object({
fullName: string().required(),
email: string().email().required(),
phone: string().required(),
message: string().required()
});

export default contactFormSchema;