using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	//+ Header
	public class MammoCalcificationTypeCS                                                                                                      // CSBuilder.cs:380
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/MammoCalcificationTypeCS";                                      // CSBuilder.cs:384
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// These are usually lucent-centered and pathognomonic in their appearance. Skin calcifications
		/// are most commonly seen along the inframammary fold, parasternally, overlying the axilla
		/// and around the areola. The individual calcific particles usually are tightly grouped, with individual
		/// groups smaller than 5 mm in greatest dimension. Atypical forms may be confirmed
		/// as skin deposits by performing additional mammographic views tangential to the overlying
		/// skin. Also note that if suspicious-appearing calcifications are adjacent to a skin surface on
		/// a given mammographic view, they actually may be dermal (hence benign) in nature, so that
		/// tangential-view mammography with or without magnification should be done prior to any
		/// intervention.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_Skin = new Coding(System, "Skin", "Skin Calcification (Typically Benign)");                                     // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// Parallel tracks, or linear tubular calcifications that are clearly associated with blood vessels.
		/// While most vascular calcification is not difficult to identify, if only a few discontinuous calcific
		/// particles are visible in a single location and if association with a tubular structure is
		/// questionable, then additional spot-compression magnification views may be needed to further characterize
		/// their nature.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_Vascular = new Coding(System, "Vascular", "Vascular Calcification (Typically Benign)");                         // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// These are the classic large (> 2 to 3 mm in greatest diameter) calcifications produced by an involuting fibroadenoma.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_Coarse = new Coding(System, "Coarse", "Coarse or 'Popcorn-like' Calcification (Typically Benign)");             // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// These benign calcifications associated with ductal ectasia may form solid or discontinuous
		/// smooth linear rods, most of which are 0.5 mm or larger in diameter. A small percentage of
		/// these calcifications may have lucent centers if the calcium is in the wall of the duct (periductal),
		/// but most are intraductal, when calcification forms within the lumen of the duct. All large
		/// rod-like calcifications follow a ductal distribution, radiating toward the nipple, occasionally
		/// branching. The calcifications usually are bilateral, although they may be seen in only one
		/// breast, especially when few calcific particles are visible. These calcifications usually are seen
		/// in women older than 60 years.)
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_LargeRodLike = new Coding(System, "LargeRodLike", "Large Rod-Like Calcification (Typically Benign)");           // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// When multiple, they may vary in size and therefore also in opacity. They may be considered
		/// benign when diffuse and small (< 1 mm), and are frequently formed in the acini of lobules. When
		/// smaller than 0.5 mm, the term "punctate" should be used.
		/// 
		/// An isolated group of punctate calcifications may warrant probably benign assessment and
		/// mammographic surveillance if no prior examinations are available for comparison, or
		/// image-guided biopsy if the group is new, increasing, linear or segmental in distribution, or if
		/// adjacent to a known cancer.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_Round = new Coding(System, "Round", "Round (Typically Benign)");                                                // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// (historically, "eggshell", "lucent-centered")
		/// These are thin benign calcifications that appear as calcium deposited on the surface of a
		/// sphere. The calcific deposits are usually less than 1 mm in thickness when viewed on edge.
		/// These are benign nongrouped calcifications that range from smaller than 1 mm to larger
		/// than a centimeter or more. The calcifications are round or oval, with smooth surfaces and
		/// lucent centers. Fat necrosis and calcifications in the walls of cysts are the most common "rim"
		/// calcifications, although more extensive (and occasionally thicker-rimmed) calcification in the
		/// walls of oil cysts or simple cysts may be seen.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_Rim = new Coding(System, "Rim", "Rim  Calcification (Typically Benign)");                                       // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// These typically form in the irradiated breast or in the breast following trauma or surgery. The
		/// calcifications are irregular in shape, and they are usually larger than 1 mm in size. They often
		/// have lucent centers.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_Dystrophic = new Coding(System, "Dystrophic", "Dystrophic Calcification (Typically Benign)");                   // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// This is a manifestation of sedimented calcifications in macro- or microcysts, usually but not
		/// always grouped. On the craniocaudal image they are often less evident and appear as round,
		/// smudgy deposits, while occasionally on MLO and especially on 90° lateral (LM/ML) views,
		/// they are more clearly defined and often semilunar, crescent shaped, curvilinear (concave up),
		/// or linear, defining the dependent portion of cysts. The most important feature of these calcifications
		/// is the apparent change in shape of the calcific particles on different mammographic
		/// projections (craniocaudal versus occasionally the MLO view and especially LM/ML views). At
		/// times milk of calcium calcifications are seen adjacent to other types of calcifications that may
		/// be associated with malignancy, so it is important to search for more suspicious forms, especially
		/// those that do not change shape from the 90º lateral projection to the CC projection.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_MilkOfCalcium = new Coding(System, "MilkOfCalcium", "Milk of Calcium Calcification (Typically Benign)");        // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// These represent calcium deposited on suture material. They are typically linear or tubular in
		/// appearance and when present, knots are frequently visible.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_Suture = new Coding(System, "Suture", "Suture Calcification (Typically Benign)");                               // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// (historically, "indistinct")
		/// These are sufficiently small and/or hazy in appearance that a more specific particle shape
		/// cannot be determined. Amorphous calcifications in a grouped, linear, or segmental distribution
		/// are suspicious and generally warrant biopsy. Bilateral, diffuse amorphous calcifications
		/// usually may be dismissed as benign, although baseline magnification views may be helpful.
		/// The positive predictive value (PPV) of amorphous calcifications is reported to be
		/// approximately 20%. Therefore, calcifications of this morphology appropriately
		/// should be placed into BI-RADS® assessment category 4B (PPV range > 10% to ? 50%).
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_Amorphous = new Coding(System, "Amorphous", "Amorphous Calcification (Suspicious Morphology)");                 // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// These are irregular, conspicuous calcifications that are generally between 0.5 mm and 1 mm
		/// and tend to coalesce, but are smaller than dystrophic calcifications. They may be associated
		/// with malignancy but more frequently are present in a fibroadenoma or in areas of fibrosis or
		/// trauma representing evolving dystrophic calcifications. Numerous bilateral groups of coarse
		/// heterogeneous calcifications usually may be dismissed as benign, although baseline magnification
		/// views may be helpful. However, a single group of coarse heterogeneous calcifications has a positive
		/// predictive value of slightly less than 15%, and therefore this finding should be
		/// placed in BI-RADS® assessment category 4B (PPV range > 10% to ? 50%).
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_CoarseHeterogeneous = new Coding(System, "CoarseHeterogeneous", "Coarse Heterogeneous Calcification (Suspicious Morphology)");// CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// These calcifications are usually more conspicuous than amorphous forms and are seen to have
		/// discrete shapes. These irregular calcifications are distinguished from fine linear and fine-linear
		/// branching forms by the absence of fine-linear particles. Fine pleomorphic calcifications vary in
		/// size and shape and are usually smaller than 0.5 mm in diameter. They have a somewhat higher
		/// PPV for malignancy (29%) than amorphous or coarse heterogeneous calcifications,
		/// but also should be placed in BI-RADS® assessment category 4B (PPV range > 10% to ? 50%).
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_FinePleomorphic = new Coding(System, "Fine Pleomorphic", "Fine Pleomorphic Calcification (Suspicious Morphology)");// CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// These are thin, linear, irregular calcifications, which may be discontinuous and which are
		/// smaller than 0.5 mm in caliber. Occasionally, branching forms may be seen. Their
		/// appearance suggests filling of the lumen of a duct or ducts involved irregularly by
		/// breast cancer. Among the suspicious calcifications, fine linear and fine-linear
		/// branching calcifications have the highest PPV (70%). Therefore, these calcifications
		/// should be placed in BI-RADS® assessment category 4C (PPV range > 50% to < 95%).
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_FineLinear = new Coding(System, "FineLinear", "Fine Linear or Fine-Linear Branching Calcification (Suspicious Morphology)");// CSBuilder.cs:410
		//- Fields
	}
}
