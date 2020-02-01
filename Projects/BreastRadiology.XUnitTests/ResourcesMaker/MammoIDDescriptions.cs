using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    public class MammoIDDescriptions
    {
        public static MammoIDDescriptions Self => self;
        static MammoIDDescriptions self = new MammoIDDescriptions();

        public class Description
        {
            public String Source;
            public String[] Text;
        }

        Dictionary<String, Description> descriptions = new Dictionary<string, Description>();

        public void Add(String id, String source, String[] text)
        {
            Description d = new Description()
            {
                Text = text,
                Source = source
            };
            this.descriptions.Add(id, d);
        }


        public bool TryGet(String id, out Description d)
        {
            return this.descriptions.TryGetValue(id, out d);
        }

        public MammoIDDescriptions()
        {
            this.descriptions = new Dictionary<string, Description>();
            //+ Data
            Add("260", 
                "UMLS", 
                new String[]
                {
                "Architectural distortion is often due to a desmoplastic ",
                "reaction in which there is focal disruption of the ",
                "normal breast tissue pattern. Architectural distortion ",
                "is among the most common presentations for breast ",
                "cancer. An architectural distortion may be caused ",
                "by sclerosing adenosis, or a thing called radial ",
                "scar, both of which are benign and both quite rare. ",
                "Architectural distortion uncommonly indicates cancer."
                });
            Add("239", 
                "UMLS", 
                new String[]
                {
                "Axillary lymphadenopathy is a condition in which ",
                "the lymph nodes of the axillary region — commonly ",
                "known as the armpit — are enlarged. The condition ",
                "can be diagnosed on the basis of a physical exam ",
                "or imaging studies."
                });
            Add("471.263", 
                "UMLS", 
                new String[]
                {
                "The biopsy clip serves as a marker documenting where ",
                "the tissue was sampled in the breast. If the original ",
                "abnormality is no longer visible by imaging after ",
                "the biopsy, the marker is the only guide we have ",
                "to know where the diseased tissue was sampled."
                });
            Add("472.264", 
                "UMLS", 
                new String[]
                {
                "Tissue marker placement after image-guided breast ",
                "biopsy has become a routine component of clinical ",
                "practice. Marker placement distinguishes multiple ",
                "biopsied lesions within the same breast, prevents ",
                "re-biopsy of benign lesions, enables multi-modality ",
                "correlation, guides pre-operative localization and ",
                "helps confirm surgical target removal. Numerous breast ",
                "tissue markers are currently available, with varied ",
                "shapes, composition, and associated bio-absorbable ",
                "components. This review serves to familiarize the ",
                "breast interventionalist with the tissue markers ",
                "most widely available in the United States today ",
                "and to provide guidance regarding selection of appropriate ",
                "markers for various clinical settings."
                });
            Add("475", 
                "UMLS", 
                new String[]
                {
                "Brachytherapy (brak-e-THER-uh-pee) is a procedure ",
                "that involves placing radioactive material inside ",
                "your body.\n",
                "\n",
                "Brachytherapy is one type of radiation therapy that's ",
                "used to treat cancer. Brachytherapy is sometimes ",
                "called internal radiation.\n",
                "\n",
                "Brachytherapy allows doctors to deliver higher doses ",
                "of radiation to more-specific areas of the body, ",
                "compared with the conventional form of radiation ",
                "therapy (external beam radiation) that projects radiation ",
                "from a machine outside of your body."
                });
            Add("255", 
                "UMLS", 
                new String[]
                {
                "A tumor of the lung that has invaded the chest wall. ",
                ""
                });
            Add("261", 
                "UMLS", 
                new String[]
                {
                "C1268682"
                });
            Add("262", 
                "UMLS", 
                new String[]
                {
                "The cooper's ligaments are fibrous bands extending ",
                "vertically from surface attach on chest wall muscles. ",
                "These ligaments maintain the shape and structure ",
                "of your breasts and help to prevent sagging. Cooper’s ",
                "ligaments support the breasts on the chest wall, ",
                "maintain their contour, and keep them in position.These ",
                "support breast tissue; they become contracted in ",
                "cancer of breast, producing dimples in overlying ",
                "skin. \n",
                "Thickening occurs when there are skin changes usually ",
                "associated with the presence of a mass, benign or ",
                "malignant, that causes shortening in the Coopers ",
                "ligenments due to fibrosis. "
                });
            Add("258", 
                "UMLS", 
                new String[]
                {
                "Edema may be due to blockage of subdermal lymphatics ",
                "by tumor cells or an inflammatory process within ",
                "the breast or axilla."
                });
            Add("478", 
                "UMLS", 
                new String[]
                {
                "A hematoma (US spelling)  is a localized bleeding ",
                "outside of blood vessels, due to either disease or ",
                "trauma including injury or surgery and may involve ",
                "blood continuing to seep from broken capillaries."
                });
            Add("477", 
                "UMLS", 
                new String[]
                {
                "Retracted nipples lie flat against the areola. The ",
                "condition can be the result of inflammation or scarring ",
                "of the tissue behind the nipple, and caused by numerous ",
                "conditions, not just cancer. ... In the case of breast ",
                "cancer, nipple retraction occurs when the tumor attacks ",
                "the duct behind the nipple, pulling it in."
                });
            Add("254", 
                "UMLS", 
                new String[]
                {
                "Pectoralis muscle invasion is when a tumor has become ",
                "large enough to invade into the pectoralis muscle. ",
                " "
                });
            Add("479", 
                "UMLS", 
                new String[]
                {
                "Post surgical scarring happens because of the incisions ",
                "needed to surgically remove tumor, cells, etc. The ",
                "amount of scarring is connected to the different ",
                "stages of wound healing. Surgical scar care should ",
                "be continued for a year. "
                });
            Add("469", 
                "UMLS", 
                new String[]
                {
                "A breast seroma is a collection (pocket) of serous ",
                "fluid that can develop after trauma to the breast ",
                "or following procedures such as breast surgery or ",
                "radiation therapy. Serous fluid is a pale yellow, ",
                "transparent fluid that contains protein, but no blood ",
                "cells or pus."
                });
            Add("473", 
                "UMLS", 
                new String[]
                {
                "A skin lesion is a part of the skin that has an abnormal ",
                "growth or appearance compared to the skin around ",
                "it.In order to diagnose a skin lesion, a dermatologist ",
                "or doctor will conduct a full physical exam. "
                });
            Add("251", 
                "UMLS", 
                new String[]
                {
                "Skin retraction (or inversion) or Skin retraction. ",
                "Breast cancers that are located near the skin or ",
                "nipple may cause scarring within the breast that ",
                "pulls at the nipple or nearby skin. Skin and nipple ",
                "retraction are more obvious when a woman raises her ",
                "arms above her head or leans forward."
                });
            Add("485", 
                "UMLS", 
                new String[]
                {
                "Most surgical clips are currently made of titanium, ",
                "and as many as 30 to 40 clips may be used during ",
                "a single surgical procedure. They remain inside the ",
                "patient's body after the wounds are healed."
                });
            Add("486", 
                "UMLS", 
                new String[]
                {
                "A series of surgical staples or clips are used during ",
                "surgery. In one push of a button the blood supply ",
                "is cut off to the anatomical part being removed and ",
                "a staple line is left in the patient and on the side ",
                "where the pathology has been removed."
                });
            Add("470", 
                "UMLS", 
                new String[]
                {
                "Diffusely increased density, skin edema, and trabecular ",
                "thickening are mammographic manifestations of the ",
                "edema and lymphatic obstruction in inflammatory carcinoma ",
                "of the breast. "
                });
            Add("233", 
                "UMLS", 
                new String[]
                {
                "Calcifications usually can't be felt, but they appear ",
                "on a mammogram. Depending on how they're clustered ",
                "and their shape, size, and number, your doctor may ",
                "want to do further tests. Big calcifications — \\\"macrocalcifications\\\" ",
                "— are usually not associated with cancer."
                });
            Add("235", 
                "UMLS", 
                new String[]
                {
                "Calcifications usually can't be felt, but they appear ",
                "on a mammogram. Depending on how they're clustered ",
                "and their shape, size, and number, your doctor may ",
                "want to do further tests. Big calcifications — \\\"macrocalcifications\\\" ",
                "— are usually not associated with cancer."
                });
            Add("234", 
                "UMLS", 
                new String[]
                {
                "Calcifications are small deposits of calcium that ",
                "show up on mammograms as bright white specks or dots ",
                "on the soft tissue background of the breasts. The ",
                "calcium readily absorbs the X-rays from mammograms"
                });
            Add("232", 
                "UMLS", 
                new String[]
                {
                "Calcifications are small deposits of calcium that ",
                "show up on mammograms as bright white specks or dots ",
                "on the soft tissue background of the breasts. "
                });
            Add("231", 
                "UMLS", 
                new String[]
                {
                "These show up as fine, white specks in a mammogram, ",
                "similar to grains of salt. They're usually noncancerous, ",
                "but certain patterns can be an early sign of cancer."
                });
            Add("237", 
                "UMLS", 
                new String[]
                {
                "The term milk of calcium (MOC) is given to dependent, ",
                "sedimented calcification within a cystic structure ",
                "or hollow organ. This sort of colloidal calcium suspension ",
                "layering can occur in various regions: renal: milk ",
                "of calcium in renal cyst (most common) breast: milk ",
                "of calcium in breast cyst."
                });
            Add("236", 
                "UMLS", 
                new String[]
                {
                "These are very thin benign calcifications that appear ",
                "as calcium is deposited on the surface of a sphere. ",
                "... Although fat necrosis can produce these thin ",
                "deposits, calcifications in the wall of cysts are ",
                "the most common 'rim' calcifications. Also called ",
                "Eggshell"
                });
            Add("36", 
                "UMLS", 
                new String[]
                {
                "Further evaluation (by way of exam, tests, etc) is ",
                "needed in order to come to any medical conclusion. ",
                " "
                });
            Add("32", 
                "UMLS", 
                new String[]
                {
                "Benign refers to a condition, tumor, or growth that ",
                "is not cancerous. This means that it does not spread ",
                "to other parts of the body. It does not invade nearby ",
                "tissue."
                });
            Add("33", 
                "UMLS", 
                new String[]
                {
                "Probably benign: means that there is a finding that ",
                "is most likely benign, but should be followed up ",
                "on in a short period of time to see if the area of ",
                "concern changes. "
                });
            Add("34", 
                "UMLS", 
                new String[]
                {
                "Suspicious abnormality: means that there are suspicious ",
                "findings that could turn out to be a  malignant cancer. ",
                "This prompts  interventional procedures, ranging ",
                "from diagnostic aspiration of cysts to biopsy of ",
                "calcifications. "
                });
            Add("176", 
                "UMLS", 
                new String[]
                {
                "A malignant finding is not suspected. A biopsy or ",
                "other test will likely still be performed in order ",
                "to determine. Likelihood of malignancy is 2% to <10%."
                });
            Add("177", 
                "UMLS", 
                new String[]
                {
                "It warrants radiologic and pathologic correlation ",
                "after tissue diagnosis. Likelihood of malignancy ",
                "is >10% to <50%. "
                });
            Add("178", 
                "UMLS", 
                new String[]
                {
                "Includes findings that have a high suspicion for ",
                "malignancy. Range for likelihood of malignancy is ",
                ">50% to <95%. It is more likely malignant versus ",
                "benign. "
                });
            Add("35", 
                "UMLS", 
                new String[]
                {
                "Almost certainly predictive of breast cancer with ",
                "a value of at least 95%."
                });
            Add("172", 
                "UMLS", 
                new String[]
                {
                "This category is only used for findings on a mammogram ",
                "that have already been shown to be cancer by a previous ",
                "biopsy.  Mammograms may be used in this way to see ",
                "how well the cancer is responding to treatment. "
                });
            Add("202", 
                "UMLS", 
                new String[]
                {
                "having increased echogenicity relative to fat or ",
                "equal to fibroglandular tissue. [TIRADS]: Increased ",
                "echogenicity relative to thyroid tissue"
                });
            Add("703", 
                "UMLS", 
                new String[]
                {
                "These are calcifications arranged in a line or showing ",
                "a branching pattern, suggesting deposits in a duct. ",
                "They tend to be distributed in a linear manner."
                });
            Add("751", 
                "UMLS", 
                new String[]
                {
                "Clustered Distribution is in regards to a type of ",
                "calcification with at least 5 calcifications occupying ",
                "a small volume of tissue."
                });
            Add("752", 
                "UMLS", 
                new String[]
                {
                "C1268689"
                });
            Add("753", 
                "UMLS", 
                new String[]
                {
                "C1268691"
                });
            Add("754", 
                "UMLS", 
                new String[]
                {
                "C1268690"
                });
            Add("755", 
                "UMLS", 
                new String[]
                {
                "C1268692"
                });
            Add("756", 
                "UMLS", 
                new String[]
                {
                "Refers to a type of calcification of the breast. ",
                "Scattered calcifications or multiple similar appearing ",
                "clusters of calcifications throughout the whole breast.\n",
                ""
                });
            Add("757", 
                "UMLS", 
                new String[]
                {
                "C1268693"
                });
            Add("702", 
                "UMLS", 
                new String[]
                {
                "C1268685"
                });
            Add("704", 
                "UMLS", 
                new String[]
                {
                "C1268677"
                });
            Add("705", 
                "UMLS", 
                new String[]
                {
                "C0333582"
                });
            Add("706", 
                "UMLS", 
                new String[]
                {
                "C1313950"
                });
            Add("701", 
                "UMLS", 
                new String[]
                {
                "Calcification happens when calcium builds up in body ",
                "tissue, blood vessels, or organs. This buildup can ",
                "harden and disrupt your body’s normal processes. ",
                "Calcium is transported through the bloodstream. It’s ",
                "also found in every cell. As a result, calcification ",
                "can occur in almost any part of the body."
                });
            Add("708", 
                "UMLS", 
                new String[]
                {
                "C1268688"
                });
            Add("710", 
                "UMLS", 
                new String[]
                {
                "C1268678"
                });
            Add("713", 
                "UMLS", 
                new String[]
                {
                "C1268680"
                });
            Add("714", 
                "UMLS", 
                new String[]
                {
                "C1268679"
                });
            Add("716", 
                "UMLS", 
                new String[]
                {
                "C1265883"
                });
            Add("718", 
                "UMLS", 
                new String[]
                {
                "C1268681"
                });
            Add("721", 
                "UMLS", 
                new String[]
                {
                "C1268683"
                });
            Add("722", 
                "UMLS", 
                new String[]
                {
                "C1268684"
                });
            Add("484", 
                "UMLS", 
                new String[]
                {
                "C1268655"
                });
            Add("78", 
                "UMLS", 
                new String[]
                {
                "C0332511"
                });
            Add("483", 
                "UMLS", 
                new String[]
                {
                "C1268654"
                });
            Add("77", 
                "UMLS", 
                new String[]
                {
                "C0332509"
                });
            Add("293", 
                "UMLS", 
                new String[]
                {
                "C1268656"
                });
            Add("294", 
                "UMLS", 
                new String[]
                {
                "C1268657"
                });
            Add("75", 
                "UMLS", 
                new String[]
                {
                "C1268649"
                });
            Add("76", 
                "UMLS", 
                new String[]
                {
                "C1268651"
                });
            Add("295", 
                "UMLS", 
                new String[]
                {
                "C1268650"
                });
            Add("561", 
                "UMLS", 
                new String[]
                {
                "More than one possibility for your diagnosis. The ",
                "process of weighing the probability of one disease ",
                "versus that of other diseases possibly accounting ",
                "for a patient's illness."
                });
            Add("104", 
                "UMLS", 
                new String[]
                {
                "An area within the body tissue that is swollen and ",
                "contains an accumulation of pus. "
                });
            Add("503", 
                "UMLS", 
                new String[]
                {
                "Angiolipoma is a rare type of lipoma — a growth made ",
                "of fat and blood vessels that develops under your ",
                "skin.  Unlike other types of lipomas, angiolipomas ",
                "are often painful or tender."
                });
            Add("948", 
                "UMLS", 
                new String[]
                {
                "Apocrine Metaplasia refers to a particular type of ",
                "cell change. ... This means that the epithelial cells ",
                "are undergoing an unexpected change. These breast ",
                "changes may show on a mammogram and biopsy as a mass ",
                "or benign lesion, or possibly even develop into a ",
                "palpable mass."
                });
            Add("946", 
                "UMLS", 
                new String[]
                {
                "In medical imaging, artifacts are misrepresentations ",
                "of tissue structures produced by imaging techniques ",
                "such as ultrasound, X-ray, CT scan, and magnetic ",
                "resonance imaging (MRI)."
                });
            Add("545", 
                "UMLS", 
                new String[]
                {
                "Atypical hyperplasia is a precancerous condition ",
                "that affects cells in the breast. Atypical hyperplasia ",
                "describes an accumulation of abnormal cells in the ",
                "breast. Atypical hyperplasia isn't cancer, but it ",
                "can be a forerunner to the development of breast ",
                "cancer."
                });
            Add("942", 
                "UMLS", 
                new String[]
                {
                "Axillary lymph nodes are the lymph nodes located ",
                "in the armpits. They can become enlarged in many ",
                "conditions including infections, lymphomas, and breast ",
                "cancers. Lymph nodes are small structures located ",
                "all over the body around blood vessels that act as ",
                "filters and can accumulate germs or cancer cells. ",
                "They are a part of the lymph system of the body. ",
                ""
                });
            Add("504", 
                "UMLS", 
                new String[]
                {
                "Carcinoma is a type of cancer that starts in cells ",
                "that make up the skin or the tissue lining organs."
                });
            Add("542", 
                "UMLS", 
                new String[]
                {
                "Carcinoma is a type of cancer that starts in cells ",
                "that make up the skin or the tissue lining organs"
                });
            Add("577", 
                "UMLS", 
                new String[]
                {
                "A breast cyst is a benign (non-cancerous) fluid-filled ",
                "sac in the breast. They are most common in pre-menopausal ",
                "women and in post-menopausal women taking hormone ",
                "therapy. Some cysts are too small to feel and others ",
                "may be quite large and uncomfortable. Sometimes there ",
                "are clusters of cysts in one breast or both."
                });
            Add("61", 
                "UMLS", 
                new String[]
                {
                "Refers to cysts that contain something more than ",
                "clear fluid. A complex breast cyst contains solid ",
                "elements suspended within the fluid, and may also ",
                "feature segmentation (septation) and some regions ",
                "of the cyst wall that are ‘thicker‘ than others."
                });
            Add("115", 
                "UMLS", 
                new String[]
                {
                "Complicated cysts are “in between” a simple cyst ",
                "and a complex cyst. A complicated breast cyst contains ",
                "solid elements suspended within the fluid, and may ",
                "also feature segmentation (septation) and some regions ",
                "of the cyst wall that are ‘thicker‘ than others. ",
                "Complicated breast cysts are one of the cystic breast ",
                "lesions that show intracystic debris which may imitate ",
                "a solid mass appearance. "
                });
            Add("582", 
                "UMLS", 
                new String[]
                {
                "Oil cysts are filled with fluid that may feel smooth ",
                "and soft/squishy. They are caused by the breakdown ",
                "of fatty tissue. "
                });
            Add("501", 
                "UMLS", 
                new String[]
                {
                "Sebaceous cysts form out of your sebaceous gland. ",
                "The sebaceous gland produces the oil (called sebum) ",
                "that coats your hair and skin.\n",
                "\n",
                "Cysts can develop if the gland or its duct (the passage ",
                "from which the oil is able to leave) becomes damaged ",
                "or blocked. This usually occurs due to a trauma to ",
                "the area."
                });
            Add("537", 
                "UMLS", 
                new String[]
                {
                "Refers to cysts that contain something more than ",
                "clear fluid. A complex breast cyst contains solid ",
                "elements suspended within the fluid, and may also ",
                "feature segmentation (septation) and some regions ",
                "of the cyst wall that are ‘thicker‘ than others."
                });
            Add("506", 
                "UMLS", 
                new String[]
                {
                "Complicated cysts are “in between” a simple cyst ",
                "and a complex cyst. A complicated breast cyst contains ",
                "solid elements suspended within the fluid, and may ",
                "also feature segmentation (septation) and some regions ",
                "of the cyst wall that are ‘thicker‘ than others. ",
                "Complicated breast cysts are one of the cystic breast ",
                "lesions that show intracystic debris which may imitate ",
                "a solid mass appearance. "
                });
            Add("505", 
                "UMLS", 
                new String[]
                {
                "A cyst is a  pocket of tissue that contains fluid, ",
                "air, or other substances. A Microcyst is small and ",
                "less than 2-3 mm. They are often in clusters and ",
                "only show up on a mammogram or ultrasound."
                });
            Add("514", 
                "UMLS", 
                new String[]
                {
                "Ductal carcinoma in situ (DCIS) is the presence of ",
                "abnormal cells inside a milk duct in the breast. ",
                "DCIS is considered the earliest form of breast cancer. ",
                "DCIS is noninvasive, meaning it hasn't spread out ",
                "of the milk duct and has a low risk of becoming invasive."
                });
            Add("572", 
                "UMLS", 
                new String[]
                {
                "Skin calcifications in the breast usually form in ",
                "dermal sweat glands after low grade folliculitis ",
                "and inspissation of sebaceous material. Calcifications ",
                "may also form in moles and other skin lesions. Often, ",
                "these calcifications are in groups as they extend ",
                "into small glands in the skin."
                });
            Add("64", 
                "UMLS", 
                new String[]
                {
                "An abnormal dilation of a duct by lipids and cellular ",
                "debris. In a mammary duct the condition, which tends ",
                "mainly to affect postmenopausal women, may be accompanied ",
                "by inflammation and infiltration by plasma cells."
                });
            Add("513", 
                "UMLS", 
                new String[]
                {
                "Breast edema is defined as a mammographic pattern ",
                "of skin thickening, increased parenchymal density, ",
                "and interstitial marking. It can be caused by benign ",
                "or malignant diseases, as a result of a tumor in ",
                "the dermal lymphatics of the breast, lymphatic congestion ",
                "caused by breast, lymphatic drainage obstruction, ",
                "or by congestive heart failure."
                });
            Add("523", 
                "UMLS", 
                new String[]
                {
                "Fat Lobule. The normal breast is composed of numerous ",
                "fat lobules mixed with dense fibroglandular tissue. ",
                "Fat lobule in breast. Yes. Breast tissue is composed ",
                "of functional elements (glands and ducts) as well ",
                "as structural elements (connective tissue and vessels). ",
                "The connective tissue (or stroma) in the breast is ",
                "composed of various proportions of fat and fibrous ",
                "tissue."
                });
            Add("509", 
                "UMLS", 
                new String[]
                {
                "Fat necrosis within the breast is a pathological ",
                "process that occurs when there is saponification ",
                "of local fat. It is a benign inflammatory process ",
                "and is becoming increasingly common with the greater ",
                "use of breast conserving surgery and mammoplasty ",
                "procedures."
                });
            Add("500", 
                "UMLS", 
                new String[]
                {
                "Another name for Hamartomas, Hamartomas represent ",
                "benign proliferation of fibrous, glandular, and fatty ",
                "tissue (hence fibro-adeno-lipoma) surrounded by a ",
                "thin capsule of connective tissue. All components ",
                "are found in normal breast tissue, which is why the ",
                "lesions are considered hamartomatous."
                });
            Add("81", 
                "UMLS", 
                new String[]
                {
                "Fibroadenomas are noncancerous breast lumps that ",
                "most commonly occur in women ages 15 to 35. "
                });
            Add("587", 
                "UMLS", 
                new String[]
                {
                "Fibroadenomas usually go away with age. By the time ",
                "a woman is menopausal, they will experience a degeneration ",
                "of the Fibroadenomas. These are non-cancerous breast ",
                "lumps. "
                });
            Add("538", 
                "UMLS", 
                new String[]
                {
                "Fibrocystic breast changes lead to the development ",
                "of fluid-filled round or oval sacs (cysts) and more ",
                "prominent scar-like (fibrous) tissue, which can make ",
                "breasts feel tender, lumpy or ropy. Fibrocystic breasts ",
                "are composed of tissue that feels lumpy or rope-like ",
                "in texture. Doctors call this nodular or glandular ",
                "breast tissue."
                });
            Add("94", 
                "UMLS", 
                new String[]
                {
                "Fibrocystic breast changes lead to the development ",
                "of fluid-filled round or oval sacs (cysts) and more ",
                "prominent scar-like (fibrous) tissue, which can make ",
                "breasts feel tender, lumpy or ropy. Fibrocystic breasts ",
                "are composed of tissue that feels lumpy or rope-like ",
                "in texture. Doctors call this nodular or glandular ",
                "breast tissue."
                });
            Add("578", 
                "UMLS", 
                new String[]
                {
                "Fibrosis may refer to the connective tissue deposition ",
                "that occurs as part of normal healing or to the excess ",
                "tissue deposition that occurs as a pathological process. ",
                "When fibrosis occurs in response to injury, the term ",
                "“scarring” is used. Some of the main types of fibrosis ",
                "that occur in the body are described below."
                });
            Add("914", 
                "UMLS", 
                new String[]
                {
                "Fibrous tissue, which extends under the skin, from ",
                "the front of the breast to the back of the chest ",
                "wall, supports the breast and gives it shape. Strands ",
                "of supportive tissue surround the breast and form ",
                "a prominent ridge called the inframammary ridge."
                });
            Add("562", 
                "UMLS", 
                new String[]
                {
                "Folliculitis is the inflammation of hair follicles ",
                "due to an infection, injury, or irritation. It is ",
                "characterized by tender, swollen areas that form ",
                "around hair follicles, often on the neck, breasts, ",
                "buttocks, and face."
                });
            Add("759", 
                "UMLS", 
                new String[]
                {
                "An increase in the amount of breast gland tissue ",
                "in boys or men, caused by an imbalance of the hormones ",
                "estrogen and testosterone. Gynecomastia can affect ",
                "one or both breasts, sometimes unevenly."
                });
            Add("552.544", 
                "UMLS", 
                new String[]
                {
                "A hamartoma is a noncancerous tumor made of an abnormal ",
                "mixture of normal tissues and cells from the area ",
                "in which it grows."
                });
            Add("112", 
                "UMLS", 
                new String[]
                {
                "A breast hematoma is a collection of blood that forms ",
                "under the skin's surface. It's not unlike having ",
                "a large bruise in your breast. The mass it forms ",
                "is not cancerous, but it can sometimes lead to inflammation, ",
                "fever, skin discoloration, and may leave behind scar ",
                "tissue that mimics the shape of a breast tumor."
                });
            Add("62", 
                "UMLS", 
                new String[]
                {
                "Intracystic tumors of the breast are uncommon and, ",
                "at the time of ultrasonography and aspiration cytology, ",
                "it is difficult to distinguish cancer from a benign ",
                "tumor. "
                });
            Add("566,941", 
                "UMLS", 
                new String[]
                {
                "Intramammary lymph nodes are defined as lymph nodes ",
                "surrounded by breast tissue."
                });
            Add("508", 
                "UMLS", 
                new String[]
                {
                "A lipoma is a slow-growing, fatty lump that's most ",
                "often situated between your skin and the underlying ",
                "muscle layer. A lipoma, which feels doughy and usually ",
                "isn't tender, moves readily with slight finger pressure. ",
                "Lipomas are usually detected in middle age. Some ",
                "people have more than one lipoma.A lipoma isn't cancer ",
                "and usually is harmless."
                });
            Add("540", 
                "UMLS", 
                new String[]
                {
                "Lymphadenopathy (or adenopathy) is, if anything, ",
                "a broader term, referring to any pathology of lymph ",
                "nodes, not necessarily resulting in increased size; ",
                "this includes abnormal number of nodes, or derangement ",
                "of internal architecture (e.g. cystic or necrotic ",
                "nodes)."
                });
            Add("524", 
                "UMLS", 
                new String[]
                {
                "Infection of the breast tissue resulting in pain, ",
                "swelling, warmth and redness."
                });
            Add("571", 
                "UMLS", 
                new String[]
                {
                "The term milk of calcium (MOC) is given to dependent, ",
                "sedimented calcification within a cystic structure ",
                "or hollow organ. This sort of colloidal calcium suspension ",
                "layering can occur in various regions: renal: milk ",
                "of calcium in renal cyst (most common) breast: mil+A:Rk ",
                "of calcium in breast cyst."
                });
            Add("944", 
                "UMLS", 
                new String[]
                {
                "Multifocal breast cancer occurs when there are two ",
                "or more tumors in the same breast. All of the tumors ",
                "begin in one original tumor. The tumors are also ",
                "all in the same quadrant — or section — of the breast."
                });
            Add("563", 
                "UMLS", 
                new String[]
                {
                "Papillary lesions are benign growths in the duct ",
                "of the breast. They comprise approximately 1 to 3 ",
                "percent of all lesions sampled by core needle biopsies. ",
                "Currently, the treatment of these lesions alternates ",
                "between radiographic follow-up and surgical excision, ",
                "and is often dependent upon physician recommendation."
                });
            Add("507", 
                "UMLS", 
                new String[]
                {
                "A benign epithelial tumor that forms on the skin ",
                "or mucous membrane."
                });
            Add("560", 
                "UMLS", 
                new String[]
                {
                "Phyllodes tumor. Phyllodes tumors (from Greek: phullon ",
                "leaf), also cystosarcoma phyllodes, cystosarcoma ",
                "phylloides and phylloides tumor, are typically large, ",
                "fast-growing masses that form from the periductal ",
                "stromal cells of the breast."
                });
            Add("590", 
                "UMLS", 
                new String[]
                {
                "A lump of scar tissue forms in the hole left after ",
                "breast tissue is removed. If scar tissue forms around ",
                "a stitch from surgery it's called a suture granuloma ",
                "and also feels like a lump. ... Scar tissue and fluid ",
                "retention can make breast tissue appear a little ",
                "firmer or rounder than before surgery and/or radiation."
                });
            Add("567.943", 
                "UMLS", 
                new String[]
                {
                "Post surgical scarring happens because of the incisions ",
                "needed to surgically remove tumor, cells, etc. The ",
                "amount of scarring is connected to the different ",
                "stages of wound healing. Surgical scar care should ",
                "be continued for a year. "
                });
            Add("568", 
                "UMLS", 
                new String[]
                {
                "Radial scar is a growth that looks like a scar when ",
                "the tissue is viewed under a microscope. It has a ",
                "central core containing benign ducts. Growing out ",
                "of this core are ducts and lobules that show evidence ",
                "of unusual changes such as cysts and epithelial hyperplasia ",
                "(overgrowth of their inner lining). Often, more than ",
                "one radial scar is present. Another term for this ",
                "condition is complex sclerosing lesions. "
                });
            Add("502", 
                "UMLS", 
                new String[]
                {
                "A mark left on the skin or within body tissue where ",
                "a wound, burn, or sore has not healed completely ",
                "and fibrous connective tissue has developed."
                });
            Add("599", 
                "UMLS", 
                new String[]
                {
                "Sclerosing adenosis is a type of adenosis in which ",
                "enlarged acini become slightly distorted by surrounded ",
                "stromal fibrosis (\\\"sclerosis\\\"). The normal lobular ",
                "architecture of the breast is maintained, but becomes ",
                "exaggerated and distorted."
                });
            Add("570", 
                "UMLS", 
                new String[]
                {
                "Large rodlike or secretory calcifications. Large ",
                "rodlike or secretory calcifications (see below) are ",
                "oriented along the axes of the ductal system. These ",
                "calcifications result from calcification of ductal ",
                "secretions. Large rodlike or secretory calcifications ",
                "are oriented along the axis of the breast ductal ",
                "system."
                });
            Add("945", 
                "UMLS", 
                new String[]
                {
                "The sentinel nodes are the first few lymph nodes ",
                "into which a tumor drains. Sentinel node biopsy involves ",
                "injecting a tracer material that helps the surgeon ",
                "locate the sentinel nodes during surgery. The sentinel ",
                "nodes are removed and analyzed in a laboratory."
                });
            Add("511.576", 
                "UMLS", 
                new String[]
                {
                "A breast seroma is a collection (pocket) of serous ",
                "fluid that can develop after trauma to the breast ",
                "or following procedures such as breast surgery or ",
                "radiation therapy. Serous fluid is a pale yellow, ",
                "transparent fluid that contains protein, but no blood ",
                "cells or pus."
                });
            Add("569", 
                "UMLS", 
                new String[]
                {
                "Vascular calcifications are mineral deposits on the ",
                "walls of your arteries and veins. These mineral deposits ",
                "sometimes stick to fatty deposits, or plaques, that ",
                "are already built up on the walls of a blood vessel."
                });
            Add("947", 
                "UMLS", 
                new String[]
                {
                "Venous stasis, is a condition of slow blood flow ",
                "in the veins, usually of the legs. Venous stasis ",
                "is a risk factor for forming blood clots in veins"
                });
            Add("324", 
                "UMLS", 
                new String[]
                {
                "A ductogram, also called a galactogram, is a special ",
                "type of mammogram used for imaging the breast ducts. ",
                "It can aid in diagnosing the cause of abnormal nipple ",
                "discharges."
                });
            Add("323", 
                "UMLS", 
                new String[]
                {
                "Scintigraphy definition is - a diagnostic technique ",
                "in which a two-dimensional picture of internal body ",
                "tissue is produced through the detection of radiation ",
                "emitted by a radioactive substance administered into ",
                "the body. "
                });
            Add("591", 
                "UMLS", 
                new String[]
                {
                "The biopsy clip serves as a marker documenting where ",
                "the tissue was sampled in the breast. If the original ",
                "abnormality is no longer visible by imaging after ",
                "the biopsy, the marker is the only guide we have ",
                "to know where the diseased tissue was sampled."
                });
            Add("910", 
                "UMLS", 
                new String[]
                {
                "Tissue marker placement after image-guided breast ",
                "biopsy has become a routine component of clinical ",
                "practice. Marker placement distinguishes multiple ",
                "biopsied lesions within the same breast, prevents ",
                "re-biopsy of benign lesions, enables multi-modality ",
                "correlation, guides pre-operative localization and ",
                "helps confirm surgical target removal. Numerous breast ",
                "tissue markers are currently available, with varied ",
                "shapes, composition, and associated bio-absorbable ",
                "components. This review serves to familiarize the ",
                "breast interventionalist with the tissue markers ",
                "most widely available in the United States today ",
                "and to provide guidance regarding selection of appropriate ",
                "markers for various clinical settings."
                });
            Add("905", 
                "UMLS", 
                new String[]
                {
                "Tissue marker placement after image-guided breast ",
                "biopsy has become a routine component of clinical ",
                "practice. Marker placement distinguishes multiple ",
                "biopsied lesions within the same breast, prevents ",
                "re-biopsy of benign lesions, enables multi-modality ",
                "correlation, guides pre-operative localization and ",
                "helps confirm surgical target removal. Numerous breast ",
                "tissue markers are currently available, with varied ",
                "shapes, composition, and associated bio-absorbable ",
                "components. "
                });
            Add("906", 
                "UMLS", 
                new String[]
                {
                "Tissue marker placement after image-guided breast ",
                "biopsy has become a routine component of clinical ",
                "practice. Marker placement distinguishes multiple ",
                "biopsied lesions within the same breast, prevents ",
                "re-biopsy of benign lesions, enables multi-modality ",
                "correlation, guides pre-operative localization and ",
                "helps confirm surgical target removal. Numerous breast ",
                "tissue markers are currently available, with varied ",
                "shapes, composition, and associated bio-absorbable ",
                "components. This review serves to familiarize the ",
                "breast interventionalist with the tissue markers ",
                "most widely available in the United States today ",
                "and to provide guidance regarding selection of appropriate ",
                "markers for various clinical settings."
                });
            Add("195", 
                "UMLS", 
                new String[]
                {
                "Hilum of lymph node, the portion of a lymph node ",
                "where the efferent vessels exit. Hilus of dentate ",
                "gyrus, part of hippocampus that contains the mossy ",
                "cells.A fatty hilum within a lymph node on CT is ",
                "considered a benign characteristic.FATTY INFILTRATION ",
                "or lipomatosis of. the lymph nodes can be defined ",
                "as a proliferation of the adipose tissue which grows ",
                "in the node from the hilus toward the cortical zone, ",
                "producing distention of the capsule and causing atrophy ",
                "of the lymphoid tissue."
                });
            Add("196", 
                "UMLS", 
                new String[]
                {
                "Hilum is the fatty part of the lymph node where the ",
                "efferent vessels exit. Loss of this fatty hilum is ",
                "an indicator to the radiologists that there is possibly ",
                "cancer in the lymph nodes.  "
                });
            Add("2", 
                "UMLS", 
                new String[]
                {
                "The property of being echo-free or appearing without ",
                "echoes on a sonographic image; a cyst filled with ",
                "clear fluid appears anechoic. "
                });
            Add("230", 
                "UMLS", 
                new String[]
                {
                "Fibrocystic breast disease, commonly called fibrocystic ",
                "breasts or fibrocystic change, is a benign (noncancerous) ",
                "condition in which the breasts feel lumpy. Fibrocystic ",
                "breasts aren't harmful or dangerous, but may be bothersome ",
                "or uncomfortable for some women."
                });
            Add("97", 
                "UMLS", 
                new String[]
                {
                "Fibroglandular tissue refers to the density and composition ",
                "of breasts. A woman with scattered fibroglandular ",
                "breast tissue has breasts made up mostly of non-dense ",
                "tissue with some areas of dense tissue. About 40 ",
                "percent of women have this type of breast tissue. ",
                ""
                });
            Add("4", 
                "UMLS", 
                new String[]
                {
                "In an ultrasound- something with high echogenicity ",
                "looks light and is called hyperechoic. Denoting a ",
                "region in an ultrasound image in which the echoes ",
                "are stronger than normal or than surrounding structures. ",
                ""
                });
            Add("3", 
                "UMLS", 
                new String[]
                {
                "Hypoechoic means an area looks darker on ultrasound ",
                "than the surrounding tissue. The surrounding tissue ",
                "therefore looks brighter/lighter shades of grey.A ",
                "hypoechoic mass means that it is solid, rather than ",
                "liquid.The lump or lesion is not a cyst. "
                });
            Add("1001", 
                "UMLS", 
                new String[]
                {
                "Just like the hands of a clock, this is how doctors ",
                "describe position of the tumor in the breast. 1 o'clock ",
                "position is at the 1 o'clock position and in the ",
                "Upper Inner Quandrant (UIQ) of the breast. "
                });
            Add("1010", 
                "UMLS", 
                new String[]
                {
                "Just like the hands of a clock, this is how doctors ",
                "describe position of the tumor in the breast. 10 ",
                "o'clock position is at the 10 o'clock position and ",
                "in the Upper Outer Quandrant (UOQ) of the breast. ",
                ""
                });
            Add("1011", 
                "UMLS", 
                new String[]
                {
                "Just like the hands of a clock, this is how doctors ",
                "describe position of the tumor in the breast. 11 ",
                "o'clock position is at the 11 o'clock position and ",
                "in the Upper Outer Quandrant (UOQ) of the breast. ",
                ""
                });
            Add("1012", 
                "UMLS", 
                new String[]
                {
                "Just like the hands of a clock, this is how doctors ",
                "describe position of the tumor in the breast. 12 ",
                "o'clock position is at the 12 o'clock position."
                });
            Add("1002", 
                "UMLS", 
                new String[]
                {
                "Just like the hands of a clock, this is how doctors ",
                "describe position of the tumor in the breast. 2 o'clock ",
                "position is at the 2 o'clock position and in the ",
                "Upper Inner Quandrant (UIQ) of the breast. "
                });
            Add("1003", 
                "UMLS", 
                new String[]
                {
                "Just like the hands of a clock, this is how doctors ",
                "describe position of the tumor in the breast. 3 o'clock ",
                "position is at the 3 o'clock position."
                });
            Add("1004", 
                "UMLS", 
                new String[]
                {
                "Just like the hands of a clock, this is how doctors ",
                "describe position of the tumor in the breast. 4 o'clock ",
                "position is at the 4 o'clock position and in the ",
                "Lower Inner Quandrant (LIQ) of the breast. "
                });
            Add("1005", 
                "UMLS", 
                new String[]
                {
                "Just like the hands of a clock, this is how doctors ",
                "describe position of the tumor in the breast. 5 o'clock ",
                "position is at the 5 o'clock position and in the ",
                "Lower Inner Quandrant (LIQ) of the breast. "
                });
            Add("1006", 
                "UMLS", 
                new String[]
                {
                "Just like the hands of a clock, this is how doctors ",
                "describe position of the tumor in the breast. 6 o'clock ",
                "position is at the 6 o'clock position."
                });
            Add("1007", 
                "UMLS", 
                new String[]
                {
                "Just like the hands of a clock, this is how doctors ",
                "describe position of the tumor in the breast. 7 o'clock ",
                "position is at the 7 o'clock position and in the ",
                "Lower Outer Quandrant (LOQ) of the breast. "
                });
            Add("1008", 
                "UMLS", 
                new String[]
                {
                "Just like the hands of a clock, this is how doctors ",
                "describe position of the tumor in the breast. 8 o'clock ",
                "position is at the 8 o'clock position and in the ",
                "Lower Outer Quandrant (LOQ) of the breast. "
                });
            Add("1009", 
                "UMLS", 
                new String[]
                {
                "Just like the hands of a clock, this is how doctors ",
                "describe position of the tumor in the breast. 9 o'clock ",
                "position is at the 9 o'clock position."
                });
            Add("1017", 
                "UMLS", 
                new String[]
                {
                "The breast is arbitrarily divided into anterior, ",
                "middle and posterior depth. he location of any lesion ",
                "is given, with reference to a quadrant or ‘clock ",
                "position,’ and the depth within the breast.\n",
                "\n",
                "The breast is arbitrarily divided into anterior, ",
                "middle and posterior depth. Anterior depth is the ",
                "outer most depth (closest to the nipple) of the breast. ",
                "\n",
                "\n",
                ""
                });
            Add("1015", 
                "UMLS", 
                new String[]
                {
                "The axilla (also, armpit, underarm or oxter) is the ",
                "area on the human body directly under the joint where ",
                "the arm connects to the shoulder. It also contains ",
                "many sweat glands. "
                });
            Add("1014", 
                "UMLS", 
                new String[]
                {
                "The tail of Spence (Spence's tail, axillary process, ",
                "axillary tail) is an extension of the tissue of the ",
                "breast that extends into the axilla. It is actually ",
                "an extension of the upper lateral quadrant of the ",
                "breast. It passes into the axilla through an opening ",
                "in the deep fascia called foramen of Langer."
                });
            Add("683", 
                "UMLS", 
                new String[]
                {
                "The lymph nodes in the neck have historically been ",
                "divided into at least six anatomic neck lymph node ",
                "levels for the purpose of head and neck cancer staging ",
                "and therapy planning. Level I lymph node is submental ",
                "and submandibular. "
                });
            Add("684", 
                "UMLS", 
                new String[]
                {
                "The lymph nodes in the neck have historically been ",
                "divided into at least six anatomic neck lymph node ",
                "levels for the purpose of head and neck cancer staging ",
                "and therapy planning. Level II is upper internal ",
                "jugular (deep cervical) chain."
                });
            Add("685", 
                "UMLS", 
                new String[]
                {
                "The lymph nodes in the neck have historically been ",
                "divided into at least six anatomic neck lymph node ",
                "levels for the purpose of head and neck cancer staging ",
                "and therapy planning. Level III: middle internal ",
                "jugular (deep cervical) chain."
                });
            Add("668", 
                "UMLS", 
                new String[]
                {
                "If the thickness at the thickest point of the cortex ",
                "was twice or greater than that at the thinnest point, ",
                "eccentric cortical thickening is considered present. ",
                "Lymph node cortical thickness and uniformity are ",
                "the most important criteria for distinguishing between ",
                "normal and abnormal nodes. "
                });
            Add("191", 
                "UMLS", 
                new String[]
                {
                "Some or all of the margin has sharp corners, often ",
                "forming acute angles. The margin of the mass is not ",
                "circumscribed. "
                });
            Add("109", 
                "UMLS", 
                new String[]
                {
                " A circumscribed margin is one that is well defined, ",
                "with an abrupt transition between the lesion and ",
                "the surrounding tissue. For US, to describe a mass ",
                "as circumscribed, its entire margin must be sharply ",
                "defined. Most circumscribed lesions have round or ",
                "oval shapes."
                });
            Add("21", 
                "UMLS", 
                new String[]
                {
                "Indistinct margin There is no clear demarcation of ",
                "the entire margin or any portion of the margin from ",
                "the surrounding tissue. The boundary is poorly defined, ",
                "and the significant feature is that the mass is not ",
                "circumscribed. "
                });
            Add("201", 
                "UMLS", 
                new String[]
                {
                "Intraductal tumor extension is a characteristic feature ",
                "of primary breast carcinoma, and is an important ",
                "consideration in patients undergoing breast conservative ",
                "surgery."
                });
            Add("20", 
                "UMLS", 
                new String[]
                {
                "Edges around the soft tissue that don't look smooth. ",
                "Indicative of some sort of growth or mass rather ",
                "than a cyst. "
                });
            Add("19", 
                "UMLS", 
                new String[]
                {
                "The edge of the mass has broad bulges. Much like ",
                "a 6 or 8 leaf clover. The edge of all of the leaves ",
                "would be lobulated. "
                });
            Add("218", 
                "UMLS", 
                new String[]
                {
                "Smooth margin with distinct separation between the ",
                "mass and the surrounding border. They are  oval-shaped ",
                "and  have a wide rather than tall formation. "
                });
            Add("111", 
                "UMLS", 
                new String[]
                {
                "The margin is characterized by short-cycle undulations ",
                "or scalloped appearance,and the margin of the mass ",
                "is not circumscribed."
                });
            Add("383", 
                "UMLS", 
                new String[]
                {
                "Microbulated or Irregular masses, a margin that is ",
                "not well defined. There is not a clear demarcation ",
                "between the mass and the surrounding tissue. "
                });
            Add("28", 
                "UMLS", 
                new String[]
                {
                "It is hidden by superimposed or adjacent fibroglandular ",
                "tissue. This is used primarily when some of the margin ",
                "of the mass is circumscribed, but the rest (more ",
                "than 25%) is hidden. "
                });
            Add("18", 
                "UMLS", 
                new String[]
                {
                "The edges of the mass have a smooth appearance and ",
                "distinct separation between the mass and surrounding ",
                "tissue. "
                });
            Add("29", 
                "UMLS", 
                new String[]
                {
                "The edges of the mass have sharp \\\"spikes\\\" coming out ",
                "from it, and the lines radiate from the mass. The ",
                "margin of the mass is not circumscribed. "
                });
            Add("284", 
                "UMLS", 
                new String[]
                {
                "A medical imaging used to view breast ducts. It can ",
                "aid in diagnosing the cause of an abnormal nipple ",
                "discharge and is valuable in diagnosing intraductal ",
                "papillomas and other conditions. "
                });
            Add("281", 
                "UMLS", 
                new String[]
                {
                "An X-Ray picture of the breast. It's used to look ",
                "for early signs of breast cancer. "
                });
            Add("283", 
                "UMLS", 
                new String[]
                {
                "Magnetic Resonance Imaging (MRI) is a test that uses ",
                "powerful magnets, radio waves, and a computer to ",
                "make detailed pictures inside your body. It helps ",
                "a doctor to diagnose a disease or injury. "
                });
            Add("285", 
                "UMLS", 
                new String[]
                {
                "This is a type of breast imaging that is used to ",
                "detect cancer cells in the breasts of some women ",
                "who have had abnormal mammograms. "
                });
            Add("282", 
                "UMLS", 
                new String[]
                {
                "Uses soundwaves to develop ultrasound images. This ",
                "information is relayed in real time to produce images ",
                "on a computer screen. This can help diagnose and ",
                "treat disease or conditions. "
                });
            Add("805", 
                "UMLS", 
                new String[]
                {
                "A medical procedure that removes tissue samples for ",
                "a biopsy. This is sometimes called a needle biopsy. ",
                ""
                });
            Add("807", 
                "UMLS", 
                new String[]
                {
                "An examination of tissue removed from the body to ",
                "discover the presence, cause or extent of a disease. ",
                ""
                });
            Add("1828", 
                "UMLS", 
                new String[]
                {
                "Advanced Technology that takes multiple images, or ",
                "X-rays, of breast tissue to recreate a 3-dimensional ",
                "picture of the breast. Also called breast tomosynthesis. ",
                ""
                });
            Add("1830", 
                "UMLS", 
                new String[]
                {
                "Advanced Technology that takes multiple images, or ",
                "X-rays, of breast tissue to recreate a 3-dimensional ",
                "picture of the breast. Cranial-Caudal (CC) is a 3D ",
                "view from above the breast. "
                });
            Add("1833", 
                "UMLS", 
                new String[]
                {
                "Advanced Technology that takes multiple images, or ",
                "X-rays, of breast tissue to recreate a 3-dimensional ",
                "picture of the breast. Lateral-medial (LM) is"
                });
            Add("1832", 
                "UMLS", 
                new String[]
                {
                "Advanced Technology that takes multiple images, or ",
                "X-rays, of breast tissue to recreate a 3-dimensional ",
                "picture of the breast. Mediolateral (ML) is"
                });
            Add("1831", 
                "UMLS", 
                new String[]
                {
                "Advanced Technology that takes multiple images, or ",
                "X-rays, of breast tissue to recreate a 3-dimensional ",
                "picture of the breast. Mediolateral-oblique (MLO) ",
                "is "
                });
            Add("1820", 
                "UMLS", 
                new String[]
                {
                "An axillary view (also known as a \\\"Cleopatra view“) ",
                "is a type of view in mammography. It is an exaggerated ",
                "craniocaudal view for better imaging of the lateral ",
                "portion of the breast to the axillary tail. This ",
                "projection is performed whenever we want to show ",
                "a lesion seen only in the axillary tail on the MLO ",
                "view. An optimal axillary view require to be clearly ",
                "displayed the most lateral portion of the breast ",
                "including the axillary tail, as well the pectoral ",
                "muscle and the nipple in profile."
                });
            Add("45", 
                "UMLS", 
                new String[]
                {
                "The tail of Spence (Spence's tail, axillary process, ",
                "axillary tail) is an extension of the tissue of the ",
                "breast that extends into the axilla. It is actually ",
                "an extension of the upper lateral quadrant of the ",
                "breast. It passes into the axilla through an opening ",
                "in the deep fascia called foramen of Langer.The Axilla ",
                "is another name for armpit. "
                });
            Add("46", 
                "UMLS", 
                new String[]
                {
                "It is useful for the study of breasts in the lower ",
                "quadrants. The patient will bend forward at the waist ",
                "to view the underside of the breast. Also called ",
                "a reverse CC view. The reversed CC view is an additional ",
                "view. It is useful for the study of breasts with ",
                "surgical scars in the lower quadrants. The ability ",
                "to see the scar through the compressor paddle offers ",
                "to the mammographer the possibility to flatten it ",
                "properly, reducing the formation of scar folds as ",
                "well artifacts from false parenchymal distortion."
                });
            Add("44", 
                "UMLS", 
                new String[]
                {
                "Also called \\\"valley view\\\" is a mammogram view that ",
                "images the most central portions of the breasts. ",
                "To get as much central tissue as possible, the mammogram ",
                "technologist will place both breasts on the plate ",
                "at the same time to image the medial half of both ",
                "breasts. "
                });
            Add("43", 
                "UMLS", 
                new String[]
                {
                "All mammograms use compression of the breast. By ",
                "applying compression to only a specific area of the ",
                "breast, the effective pressure is increased on that ",
                "spot. This results in better tissue separation and ",
                "allows better visualization of the area of the breast ",
                "needing additional examination. "
                });
            Add("185", 
                "UMLS", 
                new String[]
                {
                "A cone compression is to catch a specific spot or ",
                "view during the mammogram. Spot views apply the compression ",
                "to a smaller area of tissue using a small compression ",
                "plate or \\\"cone\\\". "
                });
            Add("1829", 
                "UMLS", 
                new String[]
                {
                "A core biopsy is a procedure where a needle is passed ",
                "through the skin to take a sample of tissue from ",
                "a mass or lump. The tissue is then examined under ",
                "a microscope for any abnormalities."
                });
            Add("332", 
                "UMLS", 
                new String[]
                {
                "Cranial-Caudal (CC) is a view from above the breast ",
                "during a mammogram or ultrasound. "
                });
            Add("168", 
                "UMLS", 
                new String[]
                {
                "Uses imaging guidance, a needle-like applicator called ",
                "a cryoprobe, and liquid nitrogen or argon gas to ",
                "create intense cold to freeze and destroy diseased ",
                "tissue, including cancer cells. It may be used to ",
                "treat a variety of skin conditions as well as tumors ",
                "within the liver, kidneys, bones, lungs and breasts."
                });
            Add("51", 
                "UMLS", 
                new String[]
                {
                "A medical procedure in which fluid or cells are drawn ",
                "out from a cyst using a needle. This is often performed ",
                "in order to do a biopsy. The needle is generally ",
                "inserted directly through the skin and may be guided ",
                "by a sonogram so the doctor can see what he's doing."
                });
            Add("1821", 
                "UMLS", 
                new String[]
                {
                "One way to get relief from the pain of a cyst is ",
                "to remove fluid from the cyst, thereby decreasing ",
                "the pressure. This is called aspiration. "
                });
            Add("108", 
                "UMLS", 
                new String[]
                {
                "This is a fine needle aspiration and is a type of ",
                "biopsy procedure. In fine needle aspiration, a thin ",
                "needle is inserted into an area of abnormal-appearing ",
                "tissue or body fluid."
                });
            Add("1834", 
                "UMLS", 
                new String[]
                {
                "While screening mammograms are used as a routine ",
                "check-up for breast health,  diagnostic mammograms ",
                "are used after suspicious results on a screening ",
                "mammogram or after some signs of breast cancer alert ",
                "the physician to check the tissue.These signs may ",
                "include a lump or breast pain. "
                });
            Add("179", 
                "UMLS", 
                new String[]
                {
                "A ductogram (galactogram) is a type of medical imaging ",
                "used to view your breast ducts. It can be helpful ",
                "in finding the cause of nipple discharge. A ductogram involves ",
                "mammography and use of a contrast agent that gets ",
                "injected into the breast, like during a breast MRI. ",
                "A blunt-tipped sialogram needle (30-gauge) is used ",
                "for performing the ductogram. The abnormal duct is ",
                "identified and cannulated. Approximately 1-2 mL of ",
                "contrast is injected. A standard two-view mammography ",
                "(or craniocaudal and mediolateral projections) are ",
                "obtained."
                });
            Add("41", 
                "UMLS", 
                new String[]
                {
                "An XCCL view is a supplementary mammographic view. ",
                "It is a type of exaggerated cranio-caudal view. It ",
                "is particularly good for imaging the lateral aspect ",
                "of the breast. It is often done when a lesion is ",
                "suspected on a MLO view but cannot be seen on the CC ",
                "view. In this view, the lateral aspect of the breast ",
                "is placed forward. One rationale of performing this ",
                "view is that many cancers are located in the lateral ",
                "aspect of the breast. An XCCM view is a supplementary ",
                "mammographic view. It is a type of exaggerated cranio-caudal ",
                "view. It is particularly good for imaging the medial ",
                "portion of the breast. In this view, the medial portion ",
                "of the breast is placed forward. A negative 15° tube ",
                "tilt is suggested.\n",
                "\n",
                "An optimal XCCM view requires the most medial portion ",
                "of the breast and the nipple in profile to be clearly ",
                "displayed."
                });
            Add("38", 
                "UMLS", 
                new String[]
                {
                "It is recommended to make a follow-up appointment. ",
                ""
                });
            Add("123", 
                "UMLS", 
                new String[]
                {
                "It is recommended to make a follow-up appointment ",
                "in 3 months."
                });
            Add("119", 
                "UMLS", 
                new String[]
                {
                "It is recommended to make a follow-up appointment ",
                "in 6 months."
                });
            Add("90", 
                "UMLS", 
                new String[]
                {
                "There are different views of the breast in mammography. ",
                "For the LM view, the tube is lateral and the detector ",
                "is placed medially\n",
                "LM view is best for evaluating medial lesions."
                });
            Add("95", 
                "UMLS", 
                new String[]
                {
                "There are different views of the breast in mammography. ",
                "The lateral view is a view obtained at virtually ",
                "every diagnostic evaluation. A lateral view may be ",
                "obtained as a mediolateral view (ML) or lateromedial ",
                "view (LM) view depending on where the imaging tube ",
                "and detector are located.\n",
                "\n",
                ""
                });
            Add("42", 
                "UMLS", 
                new String[]
                {
                "A magnification view in mammography is performed ",
                "to evaluate and count microcalcifications and its ",
                "extension (as well the assessment of the borders ",
                "and the tissue structures of a suspicious area or ",
                "a mass) by using a magnification device which brings ",
                "the breast away from the film plate and closer to ",
                "the x-ray source. This allows the acquisition of ",
                "magnified images (1.5x to 2x magnification) of the ",
                "region of interest. "
                });
            Add("1822", 
                "UMLS", 
                new String[]
                {
                "A three month follow-up is recommended. "
                });
            Add("1823", 
                "UMLS", 
                new String[]
                {
                "A six month follow-up is recommended. "
                });
            Add("1826", 
                "UMLS", 
                new String[]
                {
                "A three month follow-up is recommended. "
                });
            Add("1827", 
                "UMLS", 
                new String[]
                {
                "A six month follow-up is recommended. "
                });
            Add("144", 
                "UMLS", 
                new String[]
                {
                "A technically adequate exam has the nipple in profile, ",
                "allows visualization of the inframammary fold and ",
                "includes the pectoralis muscle extending down to ",
                "the posterior nipple line (an oblique line drawn ",
                "straight back from the nipple.)"
                });
            Add("1837", 
                "UMLS", 
                new String[]
                {
                "A stereotactic breast biopsy may be performed when ",
                "a mammogram shows a breast abnormality such as: a ",
                "suspicious mass. microcalcifications, which are a ",
                "tiny cluster of small calcium deposits. a distortion ",
                "in the structure of the breast tissue."
                });
            Add("133", 
                "UMLS", 
                new String[]
                {
                "Stereotactic Vacuum Assisted Biopsy. ... During this ",
                "type of biopsy, small samples of tissue are removed ",
                "from the breast using a hollow needle, which is precisely ",
                "guided to the correct location using x-rays and computer ",
                "generated coordinates of the concerning area of breast ",
                "tissue."
                });
            Add("132", 
                "UMLS", 
                new String[]
                {
                "A vacuum assisted biopsy is a way of removing an ",
                "area of abnormal cells from the breast tissue. A ",
                "doctor or nurse uses a special needle attached to ",
                "a vacuum device to remove the cells. The samples ",
                "can then be examined under a microscope. This can ",
                "show whether there is a cancer or another type of ",
                "breast condition."
                });
            Add("49", 
                "UMLS", 
                new String[]
                {
                "Given that the rolled projections can be performed ",
                "from any standard projection, the most commonly used ",
                "is certainly the cranio-caudal one. \n",
                "A rolled CC view- It's performed to locate a lesion ",
                "only visible in the cranio-caudal view, or when overlapped ",
                "tissues in the standard view can simulate or partially ",
                "conceal a lesion: changing of  tissues distribution ",
                " allows to determine whether or not its presence. ",
                "The breast is positioned on the image receptor as ",
                "for the cranio-caudal view, then is rotated medially ",
                "or laterally around the axis of the nipple prior ",
                "to applying compression."
                });
            Add("1807", 
                "UMLS", 
                new String[]
                {
                "This is a fine needle aspiration and is a type of ",
                "biopsy procedure. In fine needle aspiration, a thin ",
                "needle is inserted into an area of abnormal-appearing ",
                "tissue or body fluid. This is also can be called ",
                "a Scinti biopsy. "
                });
            Add("102", 
                "UMLS", 
                new String[]
                {
                "Scintimammography is also known as nuclear medicine ",
                "breast imaging, Breast Specific Gamma Imaging (BSGI) ",
                "and Molecular Breast Imaging (MBI). Your doctor may ",
                "use this exam to investigate a breast abnormality ",
                "found with mammography."
                });
            Add("1801", 
                "UMLS", 
                new String[]
                {
                "A spot view (also known as a spot compression view or focal ",
                "compression view) is an additional mammographic view performed ",
                "by applying the compression to a smaller area of ",
                "tissue using a small compression paddle, increasing ",
                "the effective pressure on that spot. This results ",
                "in better tissue separation and allows better visualization ",
                "of the breast tissue in that area. It is used to ",
                "distinguish between the presence of a true lesion ",
                "and an overlap of tissues, as well to better show ",
                "the borders of an abnormality or questionable area ",
                "or a little cluster of faint microcalcifications ",
                "in a dense area. The improved resolution is due to ",
                "the increased reduction of thickness in the examined ",
                "area and by getting the suspicious area closer to ",
                "the detector surface."
                });
            Add("54", 
                "UMLS", 
                new String[]
                {
                "Stereotactic breast biopsy uses mammography – a specific ",
                "type of breast imaging that uses low-dose x-rays ",
                "— to help locate a breast abnormality and remove ",
                "a tissue sample for examination under a microscope. ",
                "It's less invasive than surgical biopsy, leaves little ",
                "to no scarring and can be an excellent way to evaluate ",
                "calcium deposits or tiny masses that are not visible ",
                "on ultrasound."
                });
            Add("131", 
                "UMLS", 
                new String[]
                {
                "A vacuum assisted biopsy is a way of removing an ",
                "area of abnormal cells from the breast tissue. A ",
                "doctor or nurse uses a special needle attached to ",
                "a vacuum device to remove the cells. The samples ",
                "can then be examined under a microscope. This can ",
                "show whether there is a cancer or another type of ",
                "breast condition. Bx: Abbreviation for biopsy, the ",
                "removal of a sample of tissue for examination or ",
                "other study. Biopsies are most frequently studied ",
                "by use of a microscope to check for possible abnormalities ",
                "such as inflammation or cancer."
                });
            Add("367", 
                "UMLS", 
                new String[]
                {
                "A septation is a description of lesion. Dark Internal ",
                "Septations” are non-enhancing lines within a mass; ",
                ""
                });
            Add("368", 
                "UMLS", 
                new String[]
                {
                "A septation is a description of lesion. “Enhancing ",
                "Internal Septations” are enhancing lines within a ",
                "mass. "
                });
            Add("369", 
                "UMLS", 
                new String[]
                {
                "A septation is a description of lesion. Dark internal ",
                "septations refers to non-enhancing septations in ",
                "an enhancing mass. These are typical for fibroadenomas, ",
                "especially when the lesion has smooth or lobulated ",
                "margins."
                });
            Add("16", 
                "UMLS", 
                new String[]
                {
                "A mass that can't be characterized by any specific ",
                "shape. "
                });
            Add("190", 
                "UMLS", 
                new String[]
                {
                "A mass that has an undulating  (having a smoothly ",
                "rising and falling form or outline) contour. "
                });
            Add("15", 
                "UMLS", 
                new String[]
                {
                "A mass that is elliptical or egg-shaped. "
                });
            Add("14", 
                "UMLS", 
                new String[]
                {
                "A mass that is spherical, ball-shaped, circular or ",
                "global. "
                });
            Add("813", 
                "UMLS", 
                new String[]
                {
                "Only visable on breast tomosynthesis. "
                });
            Add("642", 
                "UMLS", 
                new String[]
                {
                "Architectural distortion is often due to a desmoplastic ",
                "reaction in which there is focal disruption of the ",
                "normal breast tissue pattern. Architectural distortion ",
                "is among the most common presentations for breast ",
                "cancer. An architectural distortion may be caused ",
                "by sclerosing adenosis, or a thing called radial ",
                "scar, both of which are benign and both quite rare. ",
                "Architectural distortion uncommonly indicates cancer."
                });
            Add("630", 
                "UMLS", 
                new String[]
                {
                "Brachytherapy may be temporary or permanent. ... ",
                "Temporary brachytherapy places radioactive material ",
                "inside a catheter for a specific amount of time and ",
                "then removes it. It is given at a low-dose rate (LDR) ",
                "or high-dose rate (HDR). Permanent brachytherapy ",
                "is also called seed implantation."
                });
            Add("69", 
                "UMLS", 
                new String[]
                {
                "A cyst is a sac-like pocket of membranous tissue ",
                "that contains fluid, air, or other substances. Cysts ",
                "can grow almost anywhere in your body or under your ",
                "skin. "
                });
            Add("610", 
                "UMLS", 
                new String[]
                {
                "Refers to cysts that contain something more than ",
                "clear fluid. A complex breast cyst contains solid ",
                "elements suspended within the fluid, and may also ",
                "feature segmentation (septation) and some regions ",
                "of the cyst wall that are ‘thicker‘ than others."
                });
            Add("657", 
                "UMLS", 
                new String[]
                {
                "Complicated cysts are “in between” a simple cyst ",
                "and a complex cyst. A complicated breast cyst contains ",
                "solid elements suspended within the fluid, and may ",
                "also feature segmentation (septation) and some regions ",
                "of the cyst wall that are ‘thicker‘ than others. ",
                "Complicated breast cysts are one of the cystic breast ",
                "lesions that show intracystic debris which may imitate ",
                "a solid mass appearance. "
                });
            Add("617", 
                "UMLS", 
                new String[]
                {
                "Is a sac-like pocket of tissue that contains fluid, ",
                "air, or other substances. A Microcyst is small and ",
                "less than 2-3 mm. They are often in clusters and ",
                "only show up on a mammogram or ultrasound. "
                });
            Add("636", 
                "UMLS", 
                new String[]
                {
                "Oil cysts are filled with fluid that may feel smooth ",
                "and soft/squishy. They are caused by the breakdown ",
                "of fatty tissue. "
                });
            Add("609", 
                "UMLS", 
                new String[]
                {
                "A simple cyst is a sac-like pocket of membranous ",
                "tissue that only contains clear fluid. "
                });
            Add("661", 
                "UMLS", 
                new String[]
                {
                "A cyst that is filled with debris and fluid substance. ",
                "It Is either considered a complex or complicated ",
                "cyst. The type of debris determines what kind of ",
                "cyst. "
                });
            Add("694.602", 
                "UMLS", 
                new String[]
                {
                "The mammographic finding of solitary dilated duct ",
                "is rare and poorly understood. There are anecdotal ",
                "reports of solitary dilated duct as the only mammographic ",
                "finding of underlying malignancy [1–10], indicating ",
                "its potential importance in the early detection of ",
                "breast cancer. However, some investigators have estimated ",
                "that the finding of solitary dilated duct has a very ",
                "low risk of malignancy [3, 9], supporting its assessment ",
                "as a benign (BI-RADS category 2) or probably benign ",
                "(BI-RADS category 3) lesion [11]. Solitary dilated ",
                "duct also has been reported to coexist with more ",
                "suspicious mammographic findings [6, 10], but in ",
                "such cases the associated mass, grouped microcalcifications, ",
                "architectural distortion, or developing asymmetry ",
                "would itself have a sufficiently high likelihood ",
                "of malignancy to prompt a suspicious (BI-RADS category ",
                "4) assessment.\n",
                "Solitary dilated duct is described and illustrated ",
                "in the current edition of the BI-RADS atlas as the ",
                "first of four mammographic findings classified as ",
                "“special cases” [12]. The accompanying text states ",
                "that “if unassociated with other suspicious clinical ",
                "or mammographic findings, it is usually of minor ",
                "clinical significance” [12]. Insofar as this statement ",
                "is made under the imprimatur of the widely read BI-RADS ",
                "atlas, it is likely to influence those practicing ",
                "radiologists without much, if any, personal experience ",
                "who encounter the rare finding of solitary dilated ",
                "duct. However, to our knowledge, to date there is ",
                "no large clinical series indicating the positive ",
                "predictive value for malignancy of solitary dilated ",
                "duct. The goal of this largescale study is to report ",
                "the clinical and pathologic outcomes for the isolated ",
                "finding of solitary dilated duct identified at screening ",
                "or diagnostic mammography.\n",
                "\n",
                "\n",
                "\n",
                "Read More: https://www.ajronline.org/doi/full/10.2214/AJR.09.2944"
                });
            Add("693.614", 
                "UMLS", 
                new String[]
                {
                "A noncancerous condition that results in clogged ",
                "ducts around your nipple. While it sometimes causes ",
                "pain, irritation and discharge, it's generally not ",
                "a cause for concern. If left untreated, it can eventually ",
                "obliterate the breast duct. "
                });
            Add("688", 
                "UMLS", 
                new String[]
                {
                "Sometimes a lump can form if an area of the fatty ",
                "breast tissue is damaged. This is called fat necrosis ",
                "(necrosis is a medical term used to describe damaged ",
                "or dead tissue).Fat necrosis feels like a firm, round ",
                "lump (or lumps) and is usually painless, but in some ",
                "people it may feel tender or even painful. The skin ",
                "around the lump may look red, bruised or occasionally ",
                "dimpled. Sometimes fat necrosis can cause the nipple ",
                "to be pulled in.\n",
                "Sometimes, within an area of fat necrosis the damaged ",
                "tissue can form a cyst containing an oily fluid (oil ",
                "cyst). Breast cysts don’t usually need any treatment ",
                "or follow-up. Most cysts go away by themselves and ",
                "are nothing to worry about. If the cyst is large ",
                "or causing discomfort, your specialist may draw off ",
                "the fluid using a fine needle and syringe."
                });
            Add("70", 
                "UMLS", 
                new String[]
                {
                "A fibroadenoma is a benign, or noncancerous, breast ",
                "tumor. Unlike a breast cancer, which grows larger ",
                "over time and can spread to other organs, a fibroadenoma ",
                "remains in the breast tissue. They’re pretty small, ",
                "too. Most are only 1 or 2 centimeters in size."
                });
            Add("631", 
                "UMLS", 
                new String[]
                {
                "A hamartoma is a mostly benign,[2] local malformation ",
                "of cells that resembles a neoplasm of local tissue ",
                "but is usually due to an overgrowth of multiple aberrant ",
                "cells, with a basis in a systemic genetic condition, ",
                "rather than a growth descended from a single mutated ",
                "cell (monoclonality), as would typically define a ",
                "benign neoplasm/tumor.[3] Despite this, many hamartomas ",
                "are found to have clonal chromosomal aberrations ",
                "that are acquired through somatic mutations, and ",
                "on this basis the term hamartoma is sometimes considered ",
                "synonymous with neoplasm. Hamartomas are by definition ",
                "benign, slow-growing or self-limiting,[2][3] though ",
                "the underlying condition may still predispose the ",
                "individual towards malignancies."
                });
            Add("632", 
                "UMLS", 
                new String[]
                {
                "A hematoma (US spelling) or haematoma (UK spelling) ",
                "is a localized bleeding outside of blood vessels, ",
                "due to either disease or trauma including injury ",
                "or surgery and may involve blood continuing to seep ",
                "from broken capillaries."
                });
            Add("634", 
                "UMLS", 
                new String[]
                {
                "Ductal carcinoma in situ (DCIS), also known as intraductal ",
                "carcinoma, is the earliest form of breast cancer. ",
                "It's a non-invasive cancer in which abnormal cells ",
                "are contained inside the milk duct of the breast."
                });
            Add("635", 
                "UMLS", 
                new String[]
                {
                "A lipoma is a lump under the skin that occurs due ",
                "to an overgrowth of fat cells. ... Lipomas can occur ",
                "anywhere on the body where fat cells are present, ",
                "but they tend to appear on the shoulders, chest, ",
                "trunk, neck, thighs, and armpits. In less common ",
                "cases, they may also form in internal organs, bones, ",
                "or muscles."
                });
            Add("654", 
                "UMLS", 
                new String[]
                {
                "Mastitis usually starts as a painful area in one ",
                "breast. It may be red or warm to the touch, or both. ",
                "You may also have fever, chills, and body aches. ",
                "It's an inflammation of breast tissue that sometimes ",
                "involves infection. It commonly affects women who ",
                "are breast-feeding (lactation mastitis). Mastitus ",
                "can occur in women who aren't breast-feeding and ",
                "also in men."
                });
            Add("648", 
                "UMLS", 
                new String[]
                {
                "Axillary Nodes. The axillary nodes are a group of ",
                "lymph nodes located in the axillary (or armpit) region ",
                "of the body. They perform the vital function of filtration ",
                "and conduction of lymph from the upper limbs, pectoral ",
                "region, and upper back.There are five axillary lymph ",
                "node groups, namely the lateral (humeral), anterior ",
                "(pectoral), posterior (subscapular), central and ",
                "apical nodes."
                });
            Add("649", 
                "UMLS", 
                new String[]
                {
                "Swollen lymph nodes usually occur as a result of ",
                "infection from bacteria or viruses. Rarely, swollen ",
                "lymph nodes are caused by cancer.\n",
                "Your lymph nodes, also called lymph glands, play ",
                "a vital role in your body's ability to fight off ",
                "infections. They function as filters, trapping viruses, ",
                "bacteria and other causes of illnesses before they ",
                "can infect other parts of your body. Common areas ",
                "where you might notice swollen lymph nodes include ",
                "your neck, under your chin, in your armpits and in ",
                "your groin."
                });
            Add("665", 
                "UMLS", 
                new String[]
                {
                "(Infraclavicular labeled at upper left.) One or two ",
                "deltopectoral lymph nodes (or infraclavicular nodes) ",
                "are found beside the cephalic vein, between the pectoralis ",
                "major and deltoideus, immediately below the clavicle ",
                ". They are situated in the course of the external ",
                "collecting trunks of the arm."
                });
            Add("650", 
                "UMLS", 
                new String[]
                {
                "Lymph nodes found within the breast tissue. "
                });
            Add("666", 
                "UMLS", 
                new String[]
                {
                "The supraclavicular lymph nodes are a set of lymph ",
                "nodes found just above the clavicle or collarbone, ",
                "toward the hollow of the neck. Lymph nodes are responsible ",
                "for filtering the lymphatic fluid of unwanted debris ",
                "and bacteria."
                });
            Add("640", 
                "UMLS", 
                new String[]
                {
                "A breast seroma is a collection (pocket) of serous ",
                "fluid that can develop after trauma to the breast ",
                "or following procedures such as breast surgery or ",
                "radiation therapy. Serous fluid is a pale yellow, ",
                "transparent fluid that contains protein, but no blood ",
                "cells or pus."
                });
            Add("664", 
                "UMLS", 
                new String[]
                {
                "The sternalis muscle is an uncommon anatomic variant ",
                "of the chest wall musculature and is of uncertain ",
                "etiology and function. Its importance lies in that ",
                "it should not be mistaken for a pathological lesion. ",
                ""
                });
            //- Data
        }
    }
}
