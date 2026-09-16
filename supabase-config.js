// Supabase Cloud Configuration for School Examination Management System
// You can enter your credentials here or directly through the 'Supabase Cloud' button in the app UI.
window.SUPABASE_CONFIG = {
    // Supabase Project URL
    url: localStorage.getItem('supabase_project_url') || 'https://dtfoaumajfkxavqbmnix.supabase.co',
    
    // Supabase Publishable / Anon Public API Key
    anonKey: localStorage.getItem('supabase_anon_key') || 'sb_publishable_vCiBb00kB9va4_7lj9of9A_U8025HO1',
    
    // Table name in Supabase for storing candidate data
    tableName: 'exam_candidates'
};
