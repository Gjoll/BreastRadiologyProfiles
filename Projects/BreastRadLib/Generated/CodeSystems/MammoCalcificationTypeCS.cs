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
	public class MammoCalcificationTypeCS                                                                                                      // CSBuilder.cs:403
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/MammoCalcificationTypeCS";                                      // CSBuilder.cs:407
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// (historically, "indistinct")These are sufficiently small and/or hazy in appearance that a more specific particle shapecannot be determined.
		/// Amorphous calcifications in a grouped, linear, or segmental distributionare suspicious and generally warrant biopsy.
		/// Bilateral, diffuse amorphous calcificationsusually may be dismissed as benign, although baseline magnification views may be helpful.The positive predictive value (PPV) of amorphous calcifications is reported to beapproximately 20%.
		/// Therefore, calcifications of this morphology appropriatelyshould be placed into BI-RADS assessment category 4B (PPV range > 10% to ? 50%).
		/// [-- Bi-Rads® Atlas — Mammography Fifth Ed. 2013]
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_Amorphous = new Coding(System, "Amorphous", "Amorphous");                                                       // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// These are the classic large (> 2 to 3 mm in greatest diameter) calcifications produced by an involuting fibroadenoma.
		/// [-- Bi-Rads® Atlas — Mammography Fifth Ed. 2013]
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_Coarse = new Coding(System, "Coarse", "Coarse");                                                                // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// These typically form in the irradiated breast or in the breast following trauma or surgery.
		/// Thecalcifications are irregular in shape, and they are usually larger than 1 mm in size.
		/// They oftenhave lucent centers.
		/// [-- Bi-Rads® Atlas — Mammography Fifth Ed. 2013]
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_Dystrophic = new Coding(System, "Dystrophic", "Dystrophic");                                                    // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_Eggshell = new Coding(System, "Eggshell", "Eggshell");                                                          // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// These are thin, linear or curvilinear irregular calcifications.
		/// They may be discontinuous.
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_Fine = new Coding(System, "Fine", "Fine");                                                                      // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Calcification happens when calcium builds up in body tissue, blood vessels, or organs.
		/// This buildup can harden and disrupt your body's normal processes.
		/// Calcium is transported through the bloodstream.
		/// It's also found in every cell.
		/// As a result, calcification can occur in almost any part of the body.
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_GenericCalcification = new Coding(System, "GenericCalcification", "Generic calcification");                     // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// These are irregular, conspicuous calcifications that are generally between 0.5 mm and 1 mmand tend to coalesce, but are smaller than dystrophic calcifications.
		/// They may be associatedwith malignancy but more frequently are present in a fibroadenoma or in areas of fibrosis ortrauma representing evolving dystrophic calcifications.
		/// Numerous bilateral groups of coarseheterogeneous calcifications usually may be dismissed as benign, although baseline magnificationviews may be helpful.
		/// However, a single group of coarse heterogeneous calcifications has a positivepredictive value of slightly less than 15%, and therefore this finding should beplaced in BI-RADS assessment category 4B (PPV range > 10% to ? 50%).
		/// [-- Bi-Rads® Atlas — Mammography Fifth Ed. 2013]
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_CourseHeterogeneous = new Coding(System, "CourseHeterogeneous", "Course Heterogeneous");                        // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Amorphous calcifications, previously known as indistinct calcifications, are a morphological descriptor for breast calcifications that are small and/or hazy such that no clearly defined shape/form can be ascribed.
		/// radiopaedia.org > articles > amorphous-calcifications-breast
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_Indistinct = new Coding(System, "Indistinct", "Indistinct");                                                    // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// These benign calcifications associated with ductal ectasia may form solid or discontinuoussmooth linear rods, most of which are 0.5 mm or larger in diameter.
		/// A small percentage ofthese calcifications may have lucent centers if the calcium is in the wall of the duct (periductal),but most are intraductal, when calcification forms within the lumen of the duct.
		/// All largerod-like calcifications follow a ductal distribution, radiating toward the nipple, occasionallybranching.
		/// The calcifications usually are bilateral, although they may be seen in only onebreast, especially when few calcific particles are visible.
		/// These calcifications usually are seenin women older than 60 years.)
		/// [-- Bi-Rads® Atlas — Mammography Fifth Ed. 2013]
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_LargeRodlike = new Coding(System, "LargeRodlike", "Large rodlike");                                             // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Layering of calcium within the calcification.
		/// -- https://radiologyassistant.nl/breast/breast-calcifications-differential-diagnosis
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_Layering = new Coding(System, "Layering", "Layering");                                                          // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Also called fine linear branching.
		/// These are thin, linear, irregular calcifications, which may be discontinuous and which aresmaller than 0.5 mm in caliber.
		/// Occasionally, branching forms may be seen.
		/// Their appearancesuggests filling of the lumen of a duct or ducts involved irregularly by breast cancer.
		/// -- Breast Imaging Reporting and Data System—Ultrasound, Second Edition#66
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_FineLinear = new Coding(System, "FineLinear", "Fine Linear");                                                   // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_LucentCentered = new Coding(System, "Lucent-centered", "Lucent-centered");                                      // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// This is a manifestation of sedimented calcifications in macro- or microcysts, usually but notalways grouped.
		/// On the craniocaudal image they are often less evident and appear as round,smudgy deposits, while occasionally on MLO and especially on 90 lateral (LM/ML) views,they are more clearly defined and often semilunar, crescent shaped, curvilinear (concave up),or linear, defining the dependent portion of cysts.
		/// The most important feature of these calcificationsis the apparent change in shape of the calcific particles on different mammographicprojections (craniocaudal versus occasionally the MLO view and especially LM/ML views).
		/// Attimes milk of calcium calcifications are seen adjacent to other types of calcifications that maybe associated with malignancy, so it is important to search for more suspicious forms, especially those that do not change shape from the 90 lateral projection to the CC projection.
		/// [-- Bi-Rads® Atlas — Mammography Fifth Ed. 2013]
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_MilkOfCalcium = new Coding(System, "MilkOfCalcium", "Milk of calcium");                                         // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// These calcifications are usually more conspicuous than amorphous forms and are seen to havediscrete shapes.
		/// These irregular calcifications are distinguished from fine linear and fine-linearbranching forms by the absence of fine-linear particles.
		/// Fine pleomorphic calcifications vary insize and shape and are usually smaller than 0.5 mm in diameter.
		/// -- Breast Imaging Reporting and Data System—Ultrasound, Second Edition#64
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_FinePleomorphic = new Coding(System, "FinePleomorphic", "Fine Pleomorphic");                                    // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_Punctate = new Coding(System, "Punctate", "Punctate");                                                          // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Eggshell or Rim CalcificationsThese are very thin benign calcifications that appear as calcium is deposited on the surface of a sphere.
		/// Fat necrosis and calcifications in the walls of cysts are the most common "rim"calcifications, although more extensive (and occasionally thicker-rimmed) calcification in thewalls of oil cysts or simple cysts may be seen.
		/// -- Breast Imaging Reporting and Data System—Ultrasound, Second Edition#49
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_Rim = new Coding(System, "Rim", "Rim");                                                                         // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// When multiple, they may vary in size and therefore also in opacity.
		/// They may be consideredbenign when diffuse and small (< 1 mm), and are frequently formed in the acini of lobules.
		/// Whensmaller than 0.5 mm, the term "punctate" should be used.An isolated group of punctate calcifications may warrant probably benign assessment andmammographic surveillance if no prior examinations are available for comparison, orimage-guided biopsy if the group is new, increasing, linear or segmental in distribution, or ifadjacent to a known cancer.
		/// [-- Bi-Rads® Atlas — Mammography Fifth Ed. 2013]
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_Round = new Coding(System, "Round", "Round");                                                                   // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// These are usually lucent-centered and pathognomonic in their appearance.
		/// Skin calcificationsare most commonly seen along the inframammary fold, parasternally, overlying the axillaand around the areola.
		/// The individual calcific particles usually are tightly grouped, with individualgroups smaller than 5 mm in greatest dimension.
		/// Skin calcifications may develop from a degenerative metaplastic process.
		/// -- Breast Imaging Reporting and Data System—Ultrasound, Second Edition#36
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_Skin = new Coding(System, "Skin", "Skin");                                                                      // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Calcifications that have formed a  spherical shape are usually associated with benign lesions.
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_Spherical = new Coding(System, "Spherical", "Spherical");                                                       // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// These represent calcium deposited on suture material.
		/// They are typically linear or tubular inappearance and when present, knots are frequently visible.
		/// [-- Bi-Rads® Atlas — Mammography Fifth Ed. 2013]
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_Suture = new Coding(System, "Suture", "Suture");                                                                // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Parallel tracks, or linear tubular calcifications that are clearly associated with blood vessels.While most vascular calcification is not difficult to identify, if only a few discontinuous calcificparticles are visible in a single location and if association with a tubular structure isquestionable, then additional spot-compression magnification views may be needed to further characterizetheir nature.
		/// [-- Bi-Rads® Atlas — Mammography Fifth Ed. 2013]
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_Vascular = new Coding(System, "Vascular", "Vascular");                                                          // CSBuilder.cs:433
		//- Fields
	}
}
