// Supabase Cloud Configuration for School Examination Management System
// You can enter your credentials here or directly through the 'Supabase Cloud' button in the app UI.
window.SUPABASE_CONFIG = {
    // Paste your Supabase Project URL here (e.g. 'https://xxxxxxxxxxxx.supabase.co')
    url: localStorage.getItem('supabase_project_url') || '',
    
    // Paste your Supabase Anon / Public API Key here
    anonKey: localStorage.getItem('supabase_anon_key') || '',
    
    // Table name in Supabase for storing candidate data
    tableName: 'exam_candidates'
};
