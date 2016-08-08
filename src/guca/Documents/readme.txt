============================================================================
+++++++++++++++++++++++++++++++ GUCA  README +++++++++++++++++++++++++++++++
============================================================================

Gurmukhi Unicode Conversion Application (GUCA)
Copyright © 2004 Sukhjinder Sidhu.

Released under the GNU General Public Licence.  For further details
regarding licensing conditions, see "licence.txt".  

============================================================================
Introduction
============================================================================

This readme file accompanies GUCA.  It is designed to be informative and
notify you of any recent additions/changes.

GUCA is an application that is designed to convert ASCII encoded, font-based
Gurmukhi text (usually Punjabi/Panjabi) into Unicode.  It is available
free-of-charge for both commercial and non-commercial use.  In addition, you
may incorporate any aspect of this program in your own applications as long
as your applications are open source.  See "licence.txt" for complete 
licensing restrictions.

Any requests for use of this source code in closed source applications
should be directed to the author.  For contact details, see below.

============================================================================
Version Details
============================================================================

The version of GUCA that this file accompanies is:

	Gurmukhi Unicode Conversion Application
	2004-11-15 - 1.3
	English (British)

============================================================================
Known Issues
============================================================================

	* Does not load style information for fonts (Bold, Italic etc.).
	
============================================================================
Release Notes
============================================================================

This release features major stability improvements over the additions to
1.2.  You can now use the custom mappings without lots of bugs!

Enjoy :D

============================================================================
Changes
============================================================================

Changes from version 1.2 to 1.3:

	* Bug fix - The XHTML export feature now converts & and < into
	  appropriate character entities to ensure full XML compliance.
	  
	* Bug fix - Temporary fix for problems with fonts.  If GUCA encounters
	  problems in loading a font, it will no longer crash.  It will now
	  revert to the default font.
	  
	* Changed 'Lipi' to 'AnmolLipi' to be more specific.
	
	* Added Skybound VisualStyles to enable better support for themes.
	
	* Custom font mappings now show progress and can be cancelled.
	
	* Custom mappings have been integrated with the Conversion Engine 
	  version 2.0.0.  This is a large overhaul and does not  maintain full 
	  backwards compatibility with older versions of the class interface 
	  (although it's easy to upgrade).
	  
	  A C++ version of the Conversion Engine will no longer be maintained
	  unless major flaws were found in the previous version.
	  
	* Added custom mapping support for the batch processor.
	
	* The transliterator is much more accurate now (although still needs
	  lots of work) and has been designed primarily for easy viewing by a 
	  person able to read English.  It has not been designed to be
	  reversable.

Changes from version 1.1 to 1.2:

	* Bug fix - Fixed problem in the repair feature when repairing:
	
		U+0A72 + U+0A40
	  
	  Originally this resulted in an additional U+0A72:
	  
		U+0A72 + U+0A40 to U+0A08 + U+0A72
	  
	  It has been changed to:
	  
		U+0A72 + U+0A40 to U+0A08
		
	* Bug fix - Udaat is now converted into Virama + ZWJ.  Hopefully, if
	  and when Udaat is encoded as a conjunct, this will be changed.  In
	  the meantime, Virama is used because visually it's the same thing.
	  
	  I'm still researching more about Udaat.  I hope to fix any problems
	  when I know more about it.  The current solution prevents a conjunct
	  forming.
	  
	* Bug fix - Contrary to the notes for the last version, converting
	  iq@k was not correctly implemented.  It has now been fixed and this
	  fix will work with similar text too.
	  
	* Bug fix - Reverted ਡ + ਼ = ਡ਼ in the repair feature.  This decomposition
	  is not officially recognised in Unicode (although it is in ISCII).
	  
	  I removed this to prevent problems with normalisation.
		
	* Added the custom Mapping Engine.  This is a significant feature
	  addition and is still under testing.
	  
	* Added transliteration feature - converts Gurmukhi Punjabi to Romanised
	  Punjabi.  This is designed to be a basic facility and is not
	  reversable.  There are problems with this feature and it is still
	  under testing.
	  
	* Added Adi Shakti (Khanda), ZWJ and ZWNJ to recognised characters in CCV.
	
	* Added a new logo and changed the about box to show this.
	  
	* Updated options dialog box to accommodate new features.

Changes from version 1.0 to 1.1:

	* Bug fix - Made changes to increase portability by determining platform
	  specific seperators for paths.
	  
	* Bug fix - Reordered tab settings for all controls.  Using the tab key
	  should no longer result in random movements from control-to-control.
	
	* Bug fix - Fixed mainly cosmetic irregularities with the Batch 
	  Processor tool.
	  
	* Bug fix - Added recognition for ਡ + ਼ = ਡ਼ in repair feature.  Changed the
	  compact feature to normalisation.
	  
	* Bug fix - When converting iq@k there used to be an invalid placement
	  of I.  This has been fixed.	
	
	* Added Unicode 4 compatiblity for conversion.  This can be disabled in
	  the options menu.
	
	* Added danda and double danda to character code viewer.
	
	* Added extra conversion mappings.  All mappings that can be seen to be
	  implemented have been.  Any remaining mappings are either technically
	  impossible (Unicode has not got the appropriate characters) or
	  unneccesary for the Anmol family of fonts. Specifically updated:
	
		æ to ਼
		¿ to ×
		‹ to ÷
		´ to ੍ਹ 
		Ú to ਃ  (if Unicode 4 support is enabled otherwise ":" is used)
		
	  In addition, conversion of the Gurmukhi number range in AnmolLipi has
	  been added:
	  
		ñ ò ó ô õ ö ÷ ø ù ú
	  
		1 2 3 4 5 6 7 8 9 0
	
	* Repair function now removes repeated signs.  For example, "੍੍੍" would
	  be repaired to "੍".
	  
	* GUCA now uses an internal representation of the conversion/repair
	  results for export.  This ensures that in operating systems that do
	  not support Unicode fully (Windows 98/ME), you will still be able to
	  export the correct text for viewing in a web browser.
	
	* I have decided to use the spelling "Punjabi" instead of "Panjabi"
	  throughout as this is more common.  GUCA has been updated to reflect
	  this preference.
	  
	* Made other small cosmetic changes throughout the program, including
	  support for the Saab font in the GUI and through the export feature.

Changes from version 0.9 to 1.0:

	* Bug fix - Fixed a bug that was accidentaly introduced in the previous
	  version which prevented the main ProgressBar control from functioning
	  correctly.
	  
	* Bug fix - Changed IsVowel() method by seperating vowels and signs.
	  All signs, including vowels can be checked using IsSign().  Only
	  vowels are detected using IsVowel().
	  
	* Added a repair feature.  This feature repairs and compacts Gurmukhi
	  text (Unicode only).  It replaces certain sequences of characters
	  with one single character which ensures that certain words and phrases
	  can only be encoded in one way.  It also features functions which 
	  re-order Gurmukhi text (specifically vowel/sign sequences) to match 
	  the Unicode standard.
	  
	  This should be applied to all Unicode text created on a system that
	  does not do this automatically.  For example, on Windows XP using the 
	  system Raavi font, any errors created are usually shown while inputing
	  text so this repair feature is not normally required (unless wanting
	  to compact the text).
	  
	* Added a character code viewer.  This gives very basic details of 
	  Gurmukhi Unicode characters.
	
	* Added a new icon for GUCA.
	  
	* The multiple file conversion tool is now the 'Batch Processor'.  It
	  has been updated to accommodate the repair feature.
	
	* The layout on the Options dialog has been changed to allow for
	  expansion.  Options for repair and batch processing have been added.
	  
	* Added basic user documentation.  It can be accessed by pressing F1.
	
Changes from version 0.8 to 0.9:

	* Bug fix - Fixed a possible bug that can cause GUCA to crash if the
	  settings file is not complete.

	* Changed the way GUCA opens files - it is now much faster.
	
	* Added prompt to warn user if they are about to convert a large amount
	  of text.  This ensures that the user knows that the conversion will
	  take more than just a few seconds.
	  
	* Vastly increased the speed of conversion by optimising the code.  
	  Also added additional property so that the ProgressBar used during
	  the conversion can be changed without creating a new object.
	  
	* Added the ability to cancel a conversion.  In order to do this, all
	  Window Messages are processed every additional 20% through the
	  conversion process.  To disable this and thus increase conversion
	  speed, set ProcessMessages to 'false'.
	  
	* Added the Multiple File Conversion Tool.  This enables a user to
	  convert many text files in one go.  It prevents the need to manually
	  load files into the GUCA main window and convert them one by one.
	
	* Updated the XHTML export feature so that it is much faster.  This
	  feature is currently very basic and doesn't format the text.
	
	* Added the ability to change the fonts used in the two main text boxes.
	  Font settings are saved in the XML configuration file.
	
Changes from version 0.7 to 0.8:

	* Bug fix - Added identification of U+0A3F as a vowel.  This  ensures
	  correct placement of conjuncts. e.g.:
	  
	  Previously, ਕਿ੍ਰ would have occurred, now ਕ੍ਰਿ.
	  
	* Bug fix - Fixed problem when "ਿ" is the one from last character and is
	  not converted.
	  
	* Bug fix - Fixed potential flaw with conjunct placement with irregular
	  vowel placements.
	
	* Changed fonts used for XHTML export.  This should ensure correct 
	  rendering of the Gurmukhi text.  If users are having problems 
	  with the letter "ਿ" (U+0A3F) being in the wrong position please try
	  using Sun's Saraswati 5 font (available to download free from 
	  http://www.sun.com/ - web site registration required).
	  
	  Full URL for font download (URL continues for two lines):
	  
	  http://jsecom15d.sun.com/ECom/EComActionServlet?StoreId=8&PartDetailId
	  =INDIAN-FONT-G-F&TransactionId=Try&LMLoadBalanced=
	
	* Forced change of long hypen to normal hypen as this can cause problems
	  with certain fonts - especially Saraswati 5.
	  
	* Created seperate class for the Conversion Engine.  This should allow
	  easy re-use in other applications.
	  
	* Conversion engine class is now entirely commented.
	
	* Updated conversion engine to use char types whenever possible and not
	  strings.  This will improve the speed of conversion.
		  
	* Due to the new implementation of the conversion engine, the speed has
	  increased by about 1000% (yes - one thousand percent!) in some crude
	  comparisons with version 0.7.
	  
	* Added basic error correction to remove duplicated vowels which are not
	  easily visible in the original text (due to the nature of the fonts).
	
	* Added error correction for mistaken vowel signs for ਐ.
	
	* Added error correction to force placement of ੁ and ੂ before ੰ or ੱ.
	  
Older changes (0.7 and before) were not documented.

============================================================================
Contact Details
============================================================================

If you wish to contact the author, please visit the GUCA website at:

	http://guca.sourceforge.net/

============================================================================
UTF-8 [en-GB]                                           2004-11-15 15:25 UTC
============================================================================