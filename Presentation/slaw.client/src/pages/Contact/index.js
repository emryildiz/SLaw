import ContactForm from "../../components/ContactForm"
import ContactCard from "../../components/ContactCard"
import styles from "./styles.module.css"
import { getLawyers } from "../../api"
import { useQuery } from "@tanstack/react-query"
import Loading from "../../components/Loading";


function Contact() {

    const query = useQuery({queryKey: ["lawyers"], queryFn: getLawyers})

    if(query.isLoading){
      return <div><Loading /></div>
    }
  
    const lawyers = query.data.data;
  return (
    <div className={styles.contact}>
        <div className={styles.title}>
            <h1>İLETİŞİM</h1>
        </div>

        <div className={styles.content}>
        <div className={styles.lawyers}>
            {
                lawyers.map((lawyer, key) => <ContactCard item={lawyer} key={key}/>)
            }
        </div>
        <ContactForm />
        </div>

        <div className={styles.location}>
            <div className={styles.title}>
            <h1>Haritadaki Yerimiz</h1>
            </div>
            <div className={styles.map}>
            <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m12!1m3!1d10249.933666594317!2d29.051781699158564!3d40.201866103469285!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!5e0!3m2!1str!2str!4v1725900437622!5m2!1str!2str"></iframe>
            </div>
        </div>
    </div>
  )
}

export default Contact