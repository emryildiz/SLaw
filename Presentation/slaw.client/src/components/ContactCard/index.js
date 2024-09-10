import styles from "./styles.module.css"
import { GoPersonFill } from "react-icons/go";
import { PiSubtitlesFill } from "react-icons/pi";
import { MdPhone, MdMail } from "react-icons/md";

function ContactCard({item}) {
  return (
    <div className={styles.contactCard}>
        <span><GoPersonFill/> {item.fullName}</span>
        <span><PiSubtitlesFill /> {item.title}</span>
        <span><MdPhone/> {item.cellPhone}</span>
        <span><MdPhone/> {item.phone}</span>
        <span><MdMail/> {item.email}</span>
    </div>
  )
}

export default ContactCard